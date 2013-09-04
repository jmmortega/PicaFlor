using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Model
{
    public class ParlamentaryGroup
    {
        #region Properties

        private int m_id;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_acronym;

        public string Acronym
        {
            get { return m_acronym; }
            set { m_acronym = value; }
        }

        private string m_congressUrl;

        public string CongressUrl
        {
            get { return m_congressUrl; }
            set { m_congressUrl = value; }
        }

        private List<ParlamentaryMember> m_parlamentaryMembers;

        public List<ParlamentaryMember> ParlamentaryMembers
        {
            get { return m_parlamentaryMembers; }
            set { m_parlamentaryMembers = value; }
        }
        
        #endregion
    }
}
