#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace IniParser.Model
{
    /// <summary>
    /// <para>Represents a collection of SectionData.</para>
    /// </summary>
    public class SectionDataCollection : ICloneable, IEnumerable<SectionData>
    {
        #region Non-public Members

        /// <summary>
        /// Data associated to this section
        /// </summary>
        readonly Dictionary<string, SectionData> sectionData;

        #endregion

        readonly IEqualityComparer<string> searchComparer;

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionDataCollection" class.
        /// </summary>
        public SectionDataCollection()
            : this(EqualityComparer<string>.Default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IniParser.Model.SectionDataCollection" class.
        /// </summary>
        /// <param name="searchComparer">
        ///     StringComparer used when accessing section names
        /// </param>
        public SectionDataCollection(IEqualityComparer<string> searchComparer)
        {
            this.searchComparer = searchComparer;

            sectionData = new Dictionary<string, SectionData>(this.searchComparer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SectionDataCollection" class
        /// from a previous instance of <see cref="SectionDataCollection".
        /// </summary>
        /// <remarks>
        /// Data is deeply copied
        /// </remarks>
        /// <param name="ori">
        /// The instance of the <see cref="SectionDataCollection" class
        /// used to create the new instance.</param>
        public SectionDataCollection(SectionDataCollection ori, IEqualityComparer<string> searchComparer)
        {
            this.searchComparer = searchComparer ?? EqualityComparer<string>.Default;

            sectionData = new Dictionary<string, SectionData>(this.searchComparer);
            foreach (var sectionData in ori)
                this.sectionData.Add(sectionData.SectionName, (SectionData)sectionData.Clone());
            ;
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone() => new SectionDataCollection(this, searchComparer);

        #endregion

        #region IEnumerable<SectionData> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<SectionData> GetEnumerator()
        {
            foreach (var sectionName in sectionData.Keys)
                yield return sectionData[sectionName];
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Properties

        /// <summary>
        /// Returns the number of SectionData elements in the collection
        /// </summary>
        public int Count => sectionData.Count;

        /// <summary>
        /// Gets the key data associated to a specified section name.
        /// </summary>
        /// <value>An instance of as <see cref="KeyDataCollection" class
        /// holding the key data from the current parsed INI data, or a <c>null</c>
        /// value if the section doesn't exist.</value>
        public KeyDataCollection this[string sectionName]
        {
            get
            {
                if (sectionData.ContainsKey(sectionName))
                    return sectionData[sectionName].Keys;

                return null;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Creates a new section with empty data.
        /// </summary>
        /// <remarks>
        /// <para>If a section with the same name exists, this operation has no effect.</para>
        /// </remarks>
        /// <param name="keyName">Name of the section to be created</param>
        /// <return><c>true</c> if the a new section with the specified name was added,
        /// <c>false</c> otherwise</return>
        /// <exception cref="ArgumentException">If the section name is not valid.</exception>
        public bool AddSection(string keyName)
        {
            // Checks valid section name
            // if ( !Assert.StringHasNoBlankSpaces(keyName) )
            //    throw new ArgumentException("Section name contain whitespaces");

            if (!ContainsSection(keyName))
            {
                sectionData.Add(keyName, new SectionData(keyName, searchComparer));
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Adds a new SectionData instance to the collection
        /// </summary>
        /// <param name="data">Data.</param>
        public void Add(SectionData data)
        {
            if (ContainsSection(data.SectionName))
                SetSectionData(data.SectionName, new SectionData(data, searchComparer));
            else
                sectionData.Add(data.SectionName, new SectionData(data, searchComparer));
        }

        /// <summary>
        /// Removes all entries from this collection
        /// </summary>
        public void Clear() => sectionData.Clear();

        /// <summary>
        /// Gets if a section with a specified name exists in the collection.
        /// </summary>
        /// <param name="keyName">Name of the section to search</param>
        /// <returns>
        /// <c>true</c> if a section with the specified name exists in the
        ///  collection <c>false</c> otherwise
        /// </returns>
        public bool ContainsSection(string keyName) => sectionData.ContainsKey(keyName);

        /// <summary>
        /// Returns the section data from a specify section given its name.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        /// <returns>
        /// An instance of a <see cref="SectionData" class
        /// holding the section data for the currently INI data
        /// </returns>
        public SectionData GetSectionData(string sectionName)
        {
            if (sectionData.ContainsKey(sectionName))
                return sectionData[sectionName];

            return null;
        }

        public void Merge(SectionDataCollection sectionsToMerge)
        {
            foreach (var sectionDataToMerge in sectionsToMerge)
            {
                var sectionDataInThis = GetSectionData(sectionDataToMerge.SectionName);

                if (sectionDataInThis == null)
                    AddSection(sectionDataToMerge.SectionName);

                this[sectionDataToMerge.SectionName].Merge(sectionDataToMerge.Keys);
            }
        }

        /// <summary>
        /// Sets the section data for given a section name.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="data">The new <see cref="SectionData"instance.</param>
        public void SetSectionData(string sectionName, SectionData data)
        {
            if (data != null) sectionData[sectionName] = data;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="keyName"></param>
        /// <return><c>true</c> if the section with the specified name was removed,
        /// <c>false</c> otherwise</return>
        public bool RemoveSection(string keyName) => sectionData.Remove(keyName);

        #endregion
    }
}