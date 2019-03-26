using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRegisterService" in both code and config file together.
[ServiceContract]
public interface IRegisterService
{
    [OperationContract]
    void DoWork();

    //[OperationContract]
    //Admin adminRegister(string name, string surName, string email, string password, string userName);

    [OperationContract]
    User userRegister(string name, string surName, string email, string password, string userName);
}
