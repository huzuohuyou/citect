using CtApiExample.CtAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchneiderElectric.CtApi.Services
{
    public class SystemModelService
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

        public Collection<string> GetEquips()
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
        /// Gets the Clusters list
        /// </summary>
        private Collection<string> GetClusters()
        {
            var tags = new Collection<string>();
            int objectHandle;

            var searchHandle = CtApiNativeMethods.FindFirst(_citectHandle, "CLUSTER", "*", string.Empty, out objectHandle, 0);

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
        /// Gets the Trend list
        /// </summary>
        private Collection<string> GetTrends()
        {
            var tags = new Collection<string>();
            int objectHandle;

            var searchHandle = CtApiNativeMethods.FindFirst(_citectHandle, "TREND", "*", string.Empty, out objectHandle, 0);

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
        /// Gets the Alarm list
        /// </summary>
        private Collection<string> GetAlarms()
        {
            var tags = new Collection<string>();
            int objectHandle;

            var searchHandle = CtApiNativeMethods.FindFirst(_citectHandle, "ALARM", "*", string.Empty, out objectHandle, 0);

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
    }
}
