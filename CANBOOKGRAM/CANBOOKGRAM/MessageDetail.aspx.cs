using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MessageDetail : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["detail"] != null)
            {
                using (_db = new CANBOOKGRAMEntities())
                {
                    int messageId = Convert.ToInt32(Request["detail"]);

                    var msg = (from x in _db.UserMessage where (x.Id == messageId && x.isActive == true) select x).SingleOrDefault();

                    var receiverId = msg.ReceiverId;
                    int senderId = msg.SenderId;

                    var senderMessage = (from x in _db.SenderMessageDetail where (x.SenderId == senderId && x.isActive == true && x.ReceiverId == receiverId) select x).ToList().OrderByDescending(x => x.Time);
                    var receiverMessage = (from x in _db.SenderMessageDetail where (x.ReceiverId == senderId && x.SenderId == receiverId && x.isActive == true) select x).ToList().OrderByDescending(x => x.Time);
                    List<SenderMessageDetail> l = new List<SenderMessageDetail>();
                    if (senderMessage.Count() > 0)
                    {
                        foreach (var item in senderMessage)
                        {
                            l.Add(item);
                        }
                    }
                    if (receiverMessage.Count() > 0)
                    {
                        foreach (var item in receiverMessage)
                        {
                            l.Add(item);
                        }
                    }

                    dlMessageDetail.DataSource = l.OrderByDescending(x => x.Time);
                    dlMessageDetail.DataBind();
                }
            }
        }
    }

    public string FindSenderId(object id)
    {
        string Name = "";
        int sid = Convert.ToInt32(id);
        CANBOOKGRAMEntities _db = new CANBOOKGRAMEntities();
        var s = (from x in _db.User where (x.Id == sid && x.isActive == true) select x).SingleOrDefault();

        if (s != null)
        {
            Name = s.FirstName + s.LastName;
        }
        return Name;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int messageId = Convert.ToInt32(Request["detail"]);
            int Id = Convert.ToInt32(Session["MyId"]);
            var msg = (from x in _db.UserMessage where (x.Id == messageId && x.isActive == true) select x).SingleOrDefault();

            int senderId = msg.SenderId;
            var receiverId = msg.ReceiverId;

            var sendMessage = (from x in _db.UserMessage where (x.SenderId == senderId && x.ReceiverId == receiverId && x.isActive == true) select x).SingleOrDefault();
            if (sendMessage == null)
            {
                SenderMessageDetail sm = new SenderMessageDetail();
                sm.SenderId = senderId;
                sm.ReceiverId = receiverId;
                sm.MessageDetail = txtMessage.Text;
                sm.isActive = true;
                sm.UserMessageId = sendMessage.Id;
                sm.Time = DateTime.Now;
                _db.SenderMessageDetail.Add(sm);
                _db.SaveChanges();
            }
            else if (senderId!=Id)
            {
                SenderMessageDetail sm = new SenderMessageDetail();
                sm.SenderId = receiverId;
                sm.ReceiverId = senderId;
                sm.MessageDetail = txtMessage.Text;
                sm.isActive = true;
                sm.UserMessageId = sendMessage.Id;
                sm.Time = DateTime.Now;
                _db.SenderMessageDetail.Add(sm);
                _db.SaveChanges();
            }
            else
            {
                SenderMessageDetail sm = new SenderMessageDetail();
                sm.SenderId = senderId;
                sm.ReceiverId = receiverId;
                sm.MessageDetail = txtMessage.Text;
                sm.isActive = true;
                sm.UserMessageId = sendMessage.Id;
                sm.Time = DateTime.Now;
                _db.SenderMessageDetail.Add(sm);
                _db.SaveChanges();
            }

            Response.Redirect("MessageDetail.aspx" + "?detail=" + messageId);
        }
    }
}