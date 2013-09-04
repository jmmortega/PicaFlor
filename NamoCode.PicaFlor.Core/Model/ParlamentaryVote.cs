using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Model
{
    public class ParlamentaryVote
    {
        private string m_title;

        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        private string m_description;

        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        private string m_vote;

        public string Vote
        {
            get { return m_vote; }
            set { m_vote = value; }
        }                        
    }
}
