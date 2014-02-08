using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductMan.Win32;
using System.Runtime.InteropServices;
using ProductMan.Utilities.Win32;

namespace ProductMan.Components
{
    public class RecipientHelper
    {
        public const int WM_USER = 0x0400;
        public const int EM_GETOLEINTERFACE = WM_USER + 60;

        private RecipientControl recipient;
        private IRichEditOle richEditOle;

        public RecipientHelper(RecipientControl item)
        {
            this.recipient = item;
        }

        internal IRichEditOle RichEditOle
        {
            get
            {
                if (richEditOle == null)
                    richEditOle = User32.SendMessage(recipient.Handle, EM_GETOLEINTERFACE, 0);
                return richEditOle;
            }
        }

        public void InsertControl(AddressMeta item)
        {
            if (item == null) return;

            Guid guid = Marshal.GenerateGuidForType(item.GetType());

            ILockBytes pLockBytes;
            OLE32.CreateILockBytesOnHGlobal(IntPtr.Zero, true, out pLockBytes);

            IStorage pStorage;
            OLE32.StgCreateDocfileOnILockBytes(pLockBytes, (uint)(STGM.STGM_SHARE_EXCLUSIVE | STGM.STGM_CREATE | STGM.STGM_READWRITE), 0, out pStorage);

            IOleClientSite pOleClientSite;
            RichEditOle.GetClientSite(out pOleClientSite);

            REOBJECT reObj = new REOBJECT();
            reObj.cp = recipient.TextLength;
            reObj.clsid = guid;
            reObj.pstg = pStorage;
            reObj.poleobj = Marshal.GetIUnknownForObject(item);
            reObj.polesite = pOleClientSite;
            reObj.dvAspect = (uint)(DVASPECT.DVASPECT_CONTENT);
            reObj.dwFlags = (uint)(REOOBJECTFLAGS.REO_BELOWBASELINE);
            reObj.dwUser = (uint)item.ID;

            RichEditOle.InsertObject(reObj);

            Marshal.ReleaseComObject(pLockBytes);
            Marshal.ReleaseComObject(pOleClientSite);
            Marshal.ReleaseComObject(pStorage);
        }

        public List<int> GetIDs()
        {
            List<int> list = new List<int>();
            int count = RichEditOle.GetObjectCount();
            for (int i = 0; i < count; i++)
            {
                REOBJECT reObj = new REOBJECT();
                RichEditOle.GetObject(i, reObj, GETOBJECTOPTIONS.REO_GETOBJ_ALL_INTERFACES);
                list.Add((int)reObj.dwUser);
            }

            return list;
        }
    }
}
