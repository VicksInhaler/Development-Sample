using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserDetails
/// </summary>
public class UserModel
{
    public int ID { get; set; }
    public int EMPLOYEENUMBER { get; set; }
    public string PASSWORD { get; set; }
    public string FIRSTNAME { get; set; }
    public string MIDDLENAME { get; set; }
    public string LASTNAME { get; set; }
    public string NICKNAME { get; set; }
    public string POSITION { get; set; }
    public string SECTION { get; set; }
    public string ROLE { get; set; }
    public string WORKSHIFT { get; set; }
    public string UPDATEDBY { get; set; }
    public UserModel()
    {

    }
  
}
