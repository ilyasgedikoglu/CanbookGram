using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendMessage : System.Web.UI.Page
{
    CANBOOKGRAMEntities _db;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MyId"] != null)
            {
                using (_db = new CANBOOKGRAMEntities())
                {
                    if (Request["delete"] != null)
                    {
                        var deleteId = Convert.ToInt32(Request["delete"]);
                        var messageDetail = (from x in _db.SenderMessageDetail where (x.UserMessageId == deleteId && x.isActive==true) select x).ToList();
                        var message = (from x in _db.UserMessage where (x.Id == deleteId && x.isActive==true) select x).SingleOrDefault();
                        foreach (var item in messageDetail)
                        {
                            item.isActive = false;
                        }
                        message.isActive = false;
                        _db.SaveChanges();
                    }

                    var users = (from x in _db.User where (x.isActive == true) select new { Id = x.Id, NameSurname = x.FirstName + " " + x.LastName }).ToList();
                    ddlUsers.DataSource = users;
                    ddlUsers.DataTextField = "NameSurname";
                    ddlUsers.DataValueField = "Id";
                    ddlUsers.DataBind();

                    int senderId = Convert.ToInt32(Session["MyId"]);
                    var messages = (from x in _db.UserMessage where ((x.isActive == true && x.SenderId == senderId)) select x).ToList();
                    var msg = (from x in _db.UserMessage where ((x.isActive == true && x.ReceiverId == senderId)) select x).ToList();

                    List<UserMessage> l = new List<UserMessage>();
                    if (messages.Count > 0)
                    {
                        foreach (var item in messages)
                        {
                            l.Add(item);
                        }
                    }
                    if (msg.Count > 0)
                    {
                        foreach (var item in msg)
                        {
                            foreach (var item2 in messages)
                            {
                                if ((item.SenderId == item2.ReceiverId) && (item.ReceiverId == item2.SenderId))
                                {
                                    break;
                                }
                                if (item.ReceiverId == item2.SenderId)
                                {
                                    l.Add(item);
                                }
                            }
                        }
                    }
                    if (messages.Count == 0)
                    {
                        foreach (var item in msg)
                        {
                            l.Add(item);
                        }
                    }

                    dlMessageBox.DataSource = l.OrderByDescending(x => x.Time);
                    dlMessageBox.DataBind();
                }
            }
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        using (_db = new CANBOOKGRAMEntities())
        {
            int senderId = Convert.ToInt32(Session["MyId"]);
            int receiverId = Convert.ToInt32(ddlUsers.SelectedItem.Value);
            var sendMessage = (from x in _db.UserMessage where (x.SenderId == senderId && x.ReceiverId == receiverId && x.isActive == true) select x).SingleOrDefault();
            var sendMessage2 = (from x in _db.UserMessage where (x.SenderId == receiverId && x.ReceiverId == senderId && x.isActive == true) select x).SingleOrDefault();
            if (sendMessage == null && sendMessage2 == null)
            {
                UserMessage m = new UserMessage();
                m.SenderId = senderId;
                m.Time = DateTime.Now;
                m.isActive = true;
                m.ReceiverId = receiverId;
                _db.UserMessage.Add(m);
                _db.SaveChanges();

                var senderMessage = (from x in _db.UserMessage where (x.SenderId == senderId && x.ReceiverId == receiverId && x.isActive == true) select x).SingleOrDefault();

                SenderMessageDetail sm = new SenderMessageDetail();
                sm.SenderId = senderId;
                sm.ReceiverId = receiverId;
                sm.MessageDetail = txtMessage.Text;
                sm.isActive = true;
                sm.UserMessageId = senderMessage.Id;
                sm.Time = DateTime.Now;
                _db.SenderMessageDetail.Add(sm);
                _db.SaveChanges();
            }
            else if (sendMessage != null && sendMessage2 == null)
            {
                var senderMessage = (from x in _db.UserMessage where (x.SenderId == senderId && x.ReceiverId == receiverId && x.isActive == true) select x).SingleOrDefault();

                SenderMessageDetail sm = new SenderMessageDetail();
                sm.SenderId = senderId;
                sm.ReceiverId = receiverId;
                sm.MessageDetail = txtMessage.Text;
                sm.isActive = true;
                sm.UserMessageId = senderMessage.Id;
                sm.Time = DateTime.Now;
                _db.SenderMessageDetail.Add(sm);
                _db.SaveChanges();
            }
            else if (sendMessage == null && sendMessage2 != null)
            {
                var senderMessage = (from x in _db.UserMessage where (x.SenderId == receiverId && x.ReceiverId == senderId && x.isActive == true) select x).SingleOrDefault();

                SenderMessageDetail sm = new SenderMessageDetail();
                sm.SenderId = senderId;
                sm.ReceiverId = receiverId;
                sm.MessageDetail = txtMessage.Text;
                sm.isActive = true;
                sm.UserMessageId = senderMessage.Id;
                sm.Time = DateTime.Now;
                _db.SenderMessageDetail.Add(sm);
                _db.SaveChanges();
            }

            Response.Redirect("SendMessage.aspx");
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

    public string FindReceiverId(object id)
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
}