#region

using System;
using System.Collections.Generic;

#endregion

namespace IniParser.Model
{
    /// <summary>
    ///     Information associated to a section in a INI File
    ///     Includes both the value and the comments associated to the key.
    /// </summary>
    public class SectionData : ICloneable
    {
        readonly IEqualityComparer<string> searchComparer;

        #region Initialization

        public SectionData(string sectionName)
            : this(sectionName, EqualityComparer<string>.Default)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SectionData" class.
        /// </summary>
        public SectionData(string sectionName, IEqualityComparer<string> searchComparer)
        {
            this.searchComparer = searchComparer;

            if (string.IsNullOrEmpty(sectionName))
                throw new ArgumentException("section name can not be empty");

            Comments = new List<string>();
            Keys = new KeyDataCollection(this.searchComparer);
            SectionName = sectionName;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SectionData" class
        ///     from a previous instance of <see cref="SectionData".
        /// </summary>
        /// <remarks>
        ///     Data is deeply copied
        /// </remarks>
        /// <param name="ori">
        ///     The instance of the <see cref="SectionData" class
        ///     used to create the new instance.
        /// </param>
        /// <param name="searchComparer">
        ///     Search comparer.
        /// </param>
        public SectionData(SectionData ori, IEqualityComparer<string> searchComparer = null)
        {
            SectionName = ori.SectionName;

            this.searchComparer = searchComparer;
            Comments = new List<string>(ori.Comments);
            Keys = new KeyDataCollection(ori.Keys, searchComparer ?? ori.searchComparer);
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        ///     Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        ///     A new object that is a copy of this instance.
        /// </returns>
        public object Clone() => new SectionData(this);

        #endregion

        #region Operations

        /// <summary>
        ///     Deletes all comments in this section and key/value pairs
        /// </summary>
        public void ClearComments()
        {
            Comments.Clear();
            Comments.Clear();
            Keys.ClearComments();
        }

        /// <summary>
        /// Deletes all the key-value pairs in this section.
        /// </summary>
		public void ClearKeyData() => Keys.RemoveAllKeys();

        /// <summary>
        ///     Merges otherSection into this, adding new keys if they don't exists
        ///     or overwriting values if the key already exists.
        /// Comments get appended.
        /// </summary>
        /// <remarks>
        ///     Comments are also merged but they are always added, not overwritten.
        /// </remarks>
        /// <param name="toMergeSection"></param>
        public void Merge(SectionData toMergeSection)
        {
            foreach (var comment in toMergeSection.Comments)
                Comments.Add(comment);

            Keys.Merge(toMergeSection.Keys);

            foreach (var comment in toMergeSection.Comments)
                Comments.Add(comment);
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the name of the section.
        /// </summary>
        /// <value>
        ///     The name of the section
        /// </value>
        public string SectionName
        {
            get
            {
                return sectionName;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                    sectionName = value;
            }
        }

        [Obsolete("Do not use this property, use property Comments instead")]
        public List<string> LeadingComments
        {
            get
            {
                return Comments;
            }

            internal set
            {
                Comments = new List<string>(value);
            }
        }

        /// <summary>
        ///     Gets or sets the comment list associated to this section.
        /// </summary>
        /// <value>
        ///     A list of strings.
        /// </value>
        public List<string> Comments { get; private set; }

        [Obsolete("Do not use this property, use property Comments instead")]
        public List<string> TrailingComments
        {
            get
            {
                return trailingComments;
            }

            internal set
            {
                trailingComments = new List<string>(value);
            }
        }

        /// <summary>
        ///     Gets or sets the keys associated to this section.
        /// </summary>
        /// <value>
        ///     A collection of KeyData objects.
        /// </value>
        public KeyDataCollection Keys { get; set; }

        #endregion

        #region Non-public members

        // Comments associated to this section

        List<string> trailingComments = new List<string>();

        // Keys associated to this section

        string sectionName;

        #endregion
    }
}