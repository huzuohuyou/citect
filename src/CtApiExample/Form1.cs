using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Citect;
using CsvHelper;
using CtApiExample.CtAPI;

namespace CtApiExample
{
    /// <summary>
    /// The form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
        #region Private Members
        /// <summary>
        /// The _citect handle for use across application
        /// </summary>
        private int _citectHandle;

        /// <summary>
        /// The _code page for translations
        /// </summary>
        private int _codePage;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Load / Open Connection

        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //timer = new System.Threading.Timer(TimerCallBack, 1, Timeout.Infinite, Timeout.Infinite);
            //_codePage = new CtApiCharsetHelper().GetCodePage(0);
            //// codePage=0 (default) maps to local machines regional setting codepage, or Encoding.Default
            //OpenConnection(txtIp.Text, txtUser.Text, txtPwd.Text);

            //load the tags dropdown
            //var tags = GetTags();
            //foreach (var tag in tags)
            //{
            //    cmbTag.Items.Add(tag);
            //}
            //if (cmbTag.Items.Count > 0) cmbTag.SelectedIndex = 0;

            //if (cmbTag.Items.Count == 0)
            //{
            //    Debug.WriteLine(@"The application failed to retrieve tags from Citect.  This application must be run in the bin folder.");
            //    //Application.Exit();
            //}




            //load the devices dropdown
            //var devices = GetDevices();
            //foreach (var device in devices)
            //{
            //    cmbDevice.Items.Add(device);
            //}
            //if (cmbDevice.Items.Count > 0) cmbDevice.SelectedIndex = 0;

            //tmrAlarm.Enabled = true;

        }


        /// <summary>
        /// Opens the connection to ctAPI
        /// </summary>
        private void OpenConnection(string computer="",string user="",string password="")
        {
            try
            {
               
                _citectHandle = CtApiNativeMethods.Open(computer, user, password, CT_OPEN.RECONNECT);
                Debug.WriteLine($@"CtApiNativeMethods.Open _citectHandle:{_citectHandle}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    @"The application failed to connect to Citect.  This application must be run in the bin folder.  Read the documentation for more details.  More info: " +
                    ex.Message + "");
                //Application.Exit();
            }
        }

        /// <summary>
        /// Gets the tag list
        /// </summary>
        private Collection<string> GetTags()
        {
            var tags = new Collection<string>();
            int objectHandle;

            var searchHandle = CtApiNativeMethods.FindFirst(_citectHandle, "TAG", "*", string.Empty, out objectHandle, 0);

            if (searchHandle == 0) return tags; //no tags, return empty list

            do
            {
                //get the tag name (or any other property) like this:
                var name = GetPropertyAsString(objectHandle, "TAG", 255);
                tags.Add(name);

            } while (CtApiNativeMethods.FindNext(searchHandle, out objectHandle));

            CtApiNativeMethods.FindClose(searchHandle);

            return tags;
        }

        /// <summary>
        /// Gets the device list
        /// </summary>
        public Collection<string> GetDevices()
        {
            var devices = new Collection<string>();
            int objectHandle;

            var searchHandle = CtApiNativeMethods.FindFirst(_citectHandle, "EQUIP", "*", string.Empty, out objectHandle,
                0);

            if (searchHandle == 0) return devices; //no tags, return empty list

            do
            {
                //get the tag name (or any other property) like this:
                var name = GetPropertyAsString(objectHandle, "IODEVICE", 255);
                devices.Add(name);

            } while (CtApiNativeMethods.FindNext(searchHandle, out objectHandle));

            CtApiNativeMethods.FindClose(searchHandle);

            return devices;
        }

        /// <summary>
        /// Helper method to get a property as a string
        /// </summary>
        /// <param name="objectHandle">The object handle.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        private string GetPropertyAsString(int objectHandle, string propertyName, uint length)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            var valueBuffer = new byte[length + 1];

            var valueBufferHandle = GCHandle.Alloc(valueBuffer, GCHandleType.Pinned);

            try
            {
                uint returnedLength;
                var returnValue = CtApiNativeMethods.GetProperty(objectHandle, propertyName,
                    valueBufferHandle.AddrOfPinnedObject(), length, out returnedLength, DbType.DBTYPE_STR);

                if (returnValue)
                {
                    return Encoding.GetEncoding(_codePage).GetString(valueBuffer, 0, (int)returnedLength);

                }
            }
            finally
            {
                valueBufferHandle.Free();
            }

            return string.Empty;
        }

        #endregion

        #region Read / Write Tags

        /// <summary>
        /// Handles the Click event of the cmdRead control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdRead_Click(object sender, EventArgs e)
        {
            txtValue.Text = string.Empty;

            var returnValue = new StringBuilder(255);
            if (CtApiNativeMethods.TagRead(_citectHandle, cmbTag.SelectedItem.ToString(), returnValue, 255))
            {
                txtValue.Text = returnValue.ToString();
            }

        }

        /// <summary>
        /// Handles the Click event of the cmdWrite control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmdWrite_Click(object sender, EventArgs e)
        {
            float val;
            if (string.IsNullOrEmpty(txtValue.Text) || !float.TryParse(txtValue.Text, out val))
            {
                Debug.WriteLine(@"This example only supports numeric types.  Enter a numeral.");
                return;
            }

            if (
                !CtApiNativeMethods.TagWrite(_citectHandle, cmbTag.SelectedItem.ToString(),
                    val.ToString(CultureInfo.InvariantCulture)))
            {
                Debug.WriteLine(@"Failed to write to " + cmbTag.SelectedItem);
                return;
            }
            txtValue.Text = string.Empty;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbTag control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = string.Empty;
        }

        #endregion

        #region Device Status

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cmbDevice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear all labels
            lblOffline.Visible = false;
            lblOnline.Visible = false;
            lblUnknown.Visible = false;

            var cicode = "IODeviceInfo(\"" + cmbDevice.SelectedItem + "\",10)";
            var returnValue = new StringBuilder(256);
            var result = CtApiNativeMethods.RunCicode(_citectHandle, cicode, 0, 0, returnValue,
                (uint)returnValue.Capacity, IntPtr.Zero);

            if (!result)
            {
                //the cicode failed, show unknown
                lblUnknown.Visible = true;
                return;
            }

            if (returnValue.ToString().Trim() == "1")
            {
                lblOnline.Visible = true;
            }
            else
            {
                lblOffline.Visible = true;
            }
        }
        #endregion

        #region Alarms

        //private void 

        private readonly object _o = new object();
        DateTime _startQueryTime=DateTime.MinValue;

        private ReadOnlyCollection<Alarm> PollForAlarms(DateTime? startQueryTime =null, DateTime? endQueryTime =null)
        {
            var alarms = new List<Alarm>();
            int soeQueryObject;
            if (Equals(null, startQueryTime)|| Equals(DateTime.MinValue, startQueryTime))
                startQueryTime = DateTimeOffset.FromUnixTimeMilliseconds(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - 2000).UtcDateTime; //get the last week of alarms
            if (Equals(null, endQueryTime))
                endQueryTime = DateTimeOffset.FromUnixTimeMilliseconds(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()).UtcDateTime;
            if (Equals(startQueryTime, endQueryTime))
                return default;
            Debug.WriteLine($@"DateTime:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")} "+ $@"startQueryTime:{startQueryTime.Value}  endQueryTime{endQueryTime.Value}");
            Debug.WriteLine($@"DateTime:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}  SOEQUERY Start");
            var priorityMin = 0;
            var priorityMax = 255;

            const string commandFormat = "SOEQUERY,{0},{1}";
            const string filterBaseString = "({0} >= {1} AND {0} <= {2})";
            var priorityString = string.Format(filterBaseString, "PRIORITY", priorityMin, priorityMax);
            var filterString = string.Format("TIMEDATE >= {0};NOT (TAG = \"\");NOT (CLASSIFICATION = \"Configuration\");NOT (CLASSIFICATION = \"Interface\");NOT (CLASSIFICATION = \"System\");NOT (CLASSIFICATION = \"Comment\");{1}", CtApiStaticMethods.DateTimeToCitectTicks(startQueryTime.Value), priorityString);
            var currentQuerySampleCount = 0;

            var query = string.Format(commandFormat, startQueryTime.Value.ToFileTimeUtc(), endQueryTime.Value.ToFileTimeUtc());
            alarms.Add(new Alarm { Tag = "SOEQUERY Start", TimestampOccurrence = DateTime.Now, TimestampCurrent = DateTime.Now });
            Debug.WriteLine($@"DateTime:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}  FindFirst Start");
            alarms.Add(new Alarm { Tag = "FindFirst Start", TimestampOccurrence = DateTime.Now, TimestampCurrent = DateTime.Now });
            var searchHandle = CtApiNativeMethods.FindFirst(_citectHandle, query, filterString, string.Empty, out soeQueryObject, 0);
            alarms.Add(new Alarm { Tag = "FindFirst End", TimestampOccurrence = DateTime.Now, TimestampCurrent = DateTime.Now });
            CtApiStaticMethods.ThrowLastCtapiError("FindFirst");
            Debug.WriteLine($@"DateTime:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}  FindFirst End");
            var validHandle = searchHandle > 0;
            try
            {
                while (validHandle)
                {
                    currentQuerySampleCount++;

                    //Get the SOE properties and generate a new alarm object
                    //The SOE properties must be retrieved for each instance

                    var alarm = new Alarm()
                    {
                        Tag = GetPropertyAsString(soeQueryObject, "TAG", 1000),

                        TimestampOccurrence = DateTime.FromFileTimeUtc(long.Parse(GetPropertyAsString(soeQueryObject, "TIMETICKS", 1000))).AddHours(8),
                        //TimestampTransition = DateTime.FromFileTimeUtc(long.Parse(GetPropertyAsString(soeQueryObject, "RECEIPTTIMETICKS", 1000))),
                        State = (AlarmState)int.Parse(GetPropertyAsString(soeQueryObject, "ALMQUERYVALUE", 1000)),
                    };

                    //Get the properties for the alarm tag
                    //Note: You can optimize this code by caching (these properties do not change with each instance)
                    int alarmQueryObject = 0;

                    CtApiNativeMethods.FindFirst(_citectHandle, "Alarm", "TAG=" + alarm.Tag, out alarmQueryObject, 0);

                    alarm.Message = GetPropertyAsString(soeQueryObject, "MESSAGE", 1000);
                    alarm.TimestampCurrent = DateTime.Now;
                    alarm.Cost = (alarm.TimestampCurrent - alarm.TimestampOccurrence).TotalSeconds.ToString();

                    //alarm.Name = GetPropertyAsString(alarmQueryObject, "NAME", 1000);

                    //alarm.Priority = GetPropertyAsString(alarmQueryObject, "PRIORITY", 1000);
                    //alarm.AlarmType = GetPropertyAsString(alarmQueryObject, "ALARMTYPE", 1000);
                    //alarm.Description = GetPropertyAsString(alarmQueryObject, "DESC", 1000);
                    //alarm.Equipment = GetPropertyAsString(alarmQueryObject, "EQUIPMENT", 1000);

                    Debug.WriteLine($@"DateTime:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}Tag:{alarm.Tag} TimestampOccurrence: {alarm.TimestampOccurrence}");
                    alarms.Add(alarm);
                    validHandle = CtApiNativeMethods.FindNext(searchHandle, out soeQueryObject);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (searchHandle > 0)
                {
                    CtApiNativeMethods.FindClose(searchHandle);
                }
            }
            alarms.Add(new Alarm { Tag = "SOEQUERY End", TimestampOccurrence = DateTime.Now, TimestampCurrent = DateTime.Now });
            Debug.WriteLine($@"DateTime:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")} SOEQUERY End");
            Debug.WriteLine($@"DateTime:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")} Alarms SOEQuery Sample Count: " + currentQuerySampleCount );
            _startQueryTime = endQueryTime.Value;
            return alarms.AsReadOnly();
        }
        /// <summary>
        /// Polls for alarms
        /// </summary>
        private async Task<ReadOnlyCollection<Alarm>> PollForAlarmsAsync()
        {
            return await Task.Run(() =>
            {
                lock (_o)
                {
                    return PollForAlarms(_startQueryTime, null);
                }
            });
        }

        public static string GetPropertyAsString2(int objectHandle, string propertyName, uint length)
        {
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            var valueBuffer = new byte[length + 1];

            var valuePtr = Marshal.UnsafeAddrOfPinnedArrayElement(valueBuffer, 0);

            var returnValue = CtApiNativeMethods.GetProperty(objectHandle, propertyName, valuePtr, length, out var returnedLength, DbType.DBTYPE_STR);

            if (!returnValue)
            {
                return string.Empty;
            }

            return valueBuffer.ToString();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            TextBoxTraceListener tbtl = new TextBoxTraceListener(TheTextBox);
            Debug.Listeners.Add(tbtl);
        }

        /// <summary>
        /// Displays the alarms in the listbox.
        /// </summary>
        /// <param name="alarms">The alarms.</param>
        private void UpdateAlarms(ReadOnlyCollection<Alarm> alarms)
        {
            if (Equals(null, alarms))
                return;
            var itemAdded = false;

            //process alarms in order
            var sortedAlarms = alarms.OrderBy(d => d.TimestampTransition.Ticks);
            txtValue.Text = $@"{sortedAlarms.Count()}";
            foreach (var alarm in sortedAlarms)
            {
                //see if the item exists
                var existing = lstAlarms.Items.Find(alarm.Id, false);
                if (existing.Any())
                {
                    var selectedItem = existing[0];
                    selectedItem.SubItems[3].Text = alarm.IsOn ? "Active" : "Inactive";
                    selectedItem.SubItems[4].Text = alarm.IsAcknowledged ? "Ack" : "Unack";
                }
                else
                {
                    //add a new entry
                    var item = new ListViewItem(alarm.TimestampOccurrence.ToLocalTime().ToString("MM/dd/yy  hh:mm:ss.fff tt")) { Tag = alarm, Name = alarm.Id };
                    item.SubItems.Add(alarm.Name);
                    item.SubItems.Add(alarm.Equipment);
                    item.SubItems.Add(alarm.IsOn ? "Active" : "Inactive");
                    item.SubItems.Add(alarm.IsAcknowledged ? "Ack" : "Unack");
                    lstAlarms.Items.Add(item);
                    itemAdded = true;
                }
            }

            if (itemAdded)
            {
                lstAlarms.Sort();   //sort based on timestamp
            }
        }

        /// <summary>
        /// Handles the Tick event of the tmrAlarm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void tmrAlarm_Tick(object sender, EventArgs e)
        {
            try
            {
                var r = await PollForAlarmsAsync();
                
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
        #endregion

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Stoptm_Click(object sender, EventArgs e)
        {
             TimerCallBack(null);
        }

        private static ConcurrentBag<Alarm> alarms = new ConcurrentBag<Alarm>();
        public async  void TimerCallBack(Object stateInfo)
        {
            try
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                var r = await PollForAlarmsAsync();
                r.ToList().ForEach(a =>
                {
                    alarms.Add(a);
                });
                
                Debug.WriteLine($@"Alarm Count:{alarms.Count}");
                var c = await SqlSugarHelper.Db.Insertable(r.ToList()).ExecuteCommandAsync();
                timer.Change(0, 2000);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
         System.Threading.Timer timer;
        private void btnTick_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmrAlarm.Enabled)
                    tmrAlarm.Stop();
                else
                    tmrAlarm.Start();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            Debug.WriteLine($@"timer Enabled {tmrAlarm.Enabled}");

        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            try
            {
                var ctApi = new CtApi();
                ctApi.Open("172.26.176.60", "HLT2", "HLT2");
                Console.WriteLine("connected");
                ctApi.Close();

                OpenConnection(txtIp.Text, txtUser.Text, txtPwd.Text);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

        }

        private int dueTime = 0;
        private int period = Timeout.Infinite;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                timer = new System.Threading.Timer(TimerCallBack, 1, dueTime, period);
                //timer.Change(10000, 10000);
                Debug.WriteLine("Timer Start");
            }
            catch (ObjectDisposedException exception)
            {
                timer = new System.Threading.Timer(TimerCallBack, 1, dueTime, period);
            }
            catch (NullReferenceException exception)
            {
                timer = new System.Threading.Timer(TimerCallBack, 1, dueTime, period);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            Debug.WriteLine("Timer Timeout.Infinite");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CtApiNativeMethods.Close(_citectHandle);
                Debug.WriteLine($@"Close Connection");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var data = alarms.ToArray();
                var a= await SqlSugarHelper.Db.Insertable(data).ExecuteCommandAsync();
                Debug.WriteLine($@"Write {a} Alarms to DB");
                alarms = new ConcurrentBag<Alarm>();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var alarmArray = alarms.ToArray();
                var alarmCsvDtos = from a in alarmArray
                                   select new AlarmCsvDto()
                                   {
                                       Tag = a.Tag,
                                       TimestampCurrent = a.TimestampCurrent,
                                       TimestampOccurrence = a.TimestampOccurrence,
                                       Cost = a.Cost,
                                       Message = a.Message
                                   };

                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Alarm.csv");
               
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(alarmCsvDtos);
                }
                Debug.WriteLine($@"Write {alarmCsvDtos.Count()} Alarms to {path}");
                alarms = new ConcurrentBag<Alarm>();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CtApiStaticMethods.ThrowLastCtapiError("FindFirst");
        }

        /// <summary>
        /// file:///C:/Program%20Files%20(x86)/Schneider%20Electric/Power%20Operation/v2021/bin/Help/SCADA%20Help/Default.htm#ctFindFirstEx.html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button7_Click(object sender, EventArgs e)
        {
            var ctApi = new CtApi();
            ctApi.Open("172.26.176.171", "HLT2", "HLT2");
            var CLUSTER = await ctApi.FindAsync("CLUSTER", "*", "", new[] { "NAME" });
            var Equip = await ctApi.FindAsync("Equip", "*", "", new[] { "NAME", "CLUSTER", "Comment" });
            var TREND = await ctApi.FindAsync("TREND", "*", "", new[] { "Cluster", "Equipment", "Tag", "EngUnits", "Item", "Comment", "Expression", "SamplePer" });
            var ALARM = await ctApi.FindAsync("ALARM", "*", "", new[] { "Cluster", "Equipment", "Tag", "Name", "Category", "Priority", "AlarmType", "AlmComment" });
            var Accum = await ctApi.FindAsync("Accum", "*", "", new[] { "EQUIPMENT", "PRIV", "AREA", "CLUSTER", "NAME", "TRIGGER", "VALUE", "RUNNING", "STARTS", "TOTALISER" });
            var TAG = await ctApi.FindAsync("TAG", "*", "", new[] { "Cluster", "Equipment", "Tag", "Comment", "EngUnits", "Item" });
        }
    }
}
