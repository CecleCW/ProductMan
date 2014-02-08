using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductMan.Components
{
    public class RecipientControl : RichTextBox
    {
        protected Dictionary<int, AddressMeta> innerList;
        protected RecipientHelper helper;

        public RecipientControl()
        {
            Multiline = false;
            innerList = new Dictionary<int, AddressMeta>();
            helper = new RecipientHelper(this);
        }

        public void AppendAddressMeta(AddressMeta meta)
        {
            if (meta.IsValid)
            {
                meta.ID = innerList.Count;
                innerList[meta.ID] = meta;
                InsertControl(meta);
            }
        }

        private void InsertControl(AddressMeta item)
        {
            helper.InsertControl(item);
        }

        public List<AddressMeta> GetRecipients()
        {
            List<int> idList = helper.GetIDs();
            List<AddressMeta> recipients = new List<AddressMeta>();
            foreach (int id in idList)
            {
                if (innerList.ContainsKey(id))
                    recipients.Add(innerList[id]);
            }

            string[] pieces = Text.Split(';');
            foreach (string email in pieces)
            {
                if (email.Trim() == "") continue;
                recipients.Add(new AddressMeta(email.Trim()));
            }

            return recipients;
        }
    }
}
