#region

using System;
using System.Collections.Generic;

#endregion

namespace IniParser.Model
{
    /// <summary>
    ///     Information associated to a key from an INI file.
    ///     Includes both the value and the comments associated to the key.
    /// </summary>
    public class KeyData : ICloneable
    {
        #region Initialization

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyData" class.
        /// </summary>
        public KeyData(string keyName)
        {
            if (string.IsNullOrEmpty(keyName))
                throw new ArgumentException("key name can not be empty");

            comments = new List<string>();
            Value = string.Empty;
            this.keyName = keyName;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="KeyData" class
        ///     from a previous instance of <see cref="KeyData".
        /// </summary>
        /// <remarks>
        ///     Data is deeply copied
        /// </remarks>
        /// <param name="ori">
        ///     The instance of the <see cref="KeyData" class
        ///     used to create the new instance.
        /// </param>
        public KeyData(KeyData ori)
        {
            Value = ori.Value;
            keyName = ori.keyName;
            comments = new List<string>(ori.comments);
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        ///     Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        ///     A new object that is a copy of this instance.
        /// </returns>
        public object Clone() => new KeyData(this);

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the comment list associated to this key.
        /// </summary>
        public List<string> Comments
        {
            get { return comments; }
            set { comments = new List<string>(value); }
        }

        /// <summary>
        ///     Gets or sets the value associated to this key.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        ///     Gets or sets the name of the key.
        /// </summary>
        public string KeyName
        {
            get
            {
                return keyName;
            }

            set
            {
                if (value != string.Empty)
                    keyName = value;
            }
        }

        #endregion Properties

        #region Non-public Members

        // List with comment lines associated to this key
        List<string> comments;

        // Unique value associated to this key

        // Name of the current key
        string keyName;

        #endregion
    }
}