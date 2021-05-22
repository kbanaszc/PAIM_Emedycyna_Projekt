using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PAIM_wyk1
{
    public abstract class Person
    {
        #region Properties and Fields


        public int Id { get; protected set; }

        public string Name
        {
            get { return this.name; }

            internal set
            {
                Debug.Assert(condition: !String.IsNullOrWhiteSpace(value));

                this.name = value;
            }
        }

        private string name;

        #endregion

        #region Constructors

        public Person(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        #endregion

        #region Methods

        public virtual string GetDescription()
        {
            return String.Format("{0}", this.Name);
        }


        #endregion
    }

}
