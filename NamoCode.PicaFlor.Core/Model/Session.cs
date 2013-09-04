using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamoCode.PicaFlor.Core.Model
{
    public class Session
    {
        private DateTime m_date;

        public DateTime Date
        {
            get { return m_date; }
            set { m_date = value; }
        }
        
        public string DateLiteral
        {
            get 
            {
                return m_date.ToString("dd/MM/yyyy");
            }            
        }


        private int m_id;

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private int m_session;

        public int SessionNumber
        {
            get { return m_session; }
            set { m_session = value; }
        }

        private List<VotingFull> m_vote;

        public List<VotingFull> Votes
        {
            get { return m_vote; }
            set { m_vote = value; }
        }


    }
}
