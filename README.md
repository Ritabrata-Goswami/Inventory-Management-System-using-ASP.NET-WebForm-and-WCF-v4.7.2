<<<<<<< HEAD
# Inventory-Management-System-using-ASP.NET-and-WCF-v4.7.2
Basic Inventory Management System that deals with Item Master, Vendor Master, GRN and Stock Out. All the Service layer and business logics are written in WCF RESTful API which is called inside Web Portal build by ASP.NET Web Form. The main intension is to separate the business logics or service layer from UI layer.

## How Project Was Created
1. First we have created a Web Form project which named  'InventoryManagement_WebPortal'.
2. By right-clicking on same solution ```Add->New Project->WCF Service Application``` and named it 'WCFService_InventoryManagement'. Inside it we deleted the older .svc (Service File) file from it and again added a new .svc and interface file by clicking ```Add->New Item```. The interface file is where controller method is defined and also url endpoint, access methods (GET, POST...), Request Format, Response Format all are described under ```[WebInvoke()]``` mwthod. Each controller method is added with ```[OperationContract]``` attribute. 
```[OperationContract]``` attribute is use to explicitly exposing that method as a service operation to clients who consuming the service. It defines the service contract, allowing WCF to recognize which methods are part of the public API.
Later we have also add a Class file in order to handling request/response JSON data primarily for type safety, structure and Serialization/Deserialization.
3. Right click on project solution the go to property. In the property tab go to ```Common properties -> Startup project```. Where change the option to ```Multiple startup projects```. Change both InventoryManagement_WebPortal and WCFService_InventoryManagement project Action to start. So that when IDE is on both Web Form and WCF start together to interact between web form and rest api.
4. Build the project. 

## CORS policy on Wcf api
Settingup CORS policy is vital in order to communicate between different domain and port. Web portal is running on ```http://localhost:50925/``` And WCF on ```http://localhost:55391/```. So CORS error is expected as port is different. To overcome this, add a global service class name ```Global.asax``` file where different event methods are given. Go to Application_BeginRequest() method and add the following. So that in every GET, POST and DELETE request begun, before it going to actual controller methods, the request goes through that Application_BeginRequest() method with added headers. Build the WCF and start. 

Global.asax:-
``` 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WCFService_InventoryManagement
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");  //This line must be first added.
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, X-Requested-With");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
```

In the UI or ASP.NET Web form, we have used ajax() to post data. And ```HttpClient(), GetAsync() and DeleteAsync()``` method to fetch the response and delete data from gridview respectively. In order to run async-await request in web form it is recommended to add Async="true" in every .aspx page. Like this,
```
<%@ Page Title="Stock-Out" Async="true" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StockOut.aspx.cs" Inherits="StockOut" %>
```
And register the method as ```RegisterAsyncTask()``` if the method is loaded with the first time page load inside Page_Load() method in .aspx.cs file.
=======
# Inventory-Management-System-using-ASP.NET-WebForm-and-WCF-v4.7.2
Basic Inventory Management System that deals with Item Master, Vendor Master, GRN and Stock Out. All the Service layer and business logics are written in WCF RESTful API which is called inside Web Portal. The main intension is to separate the business logics or service layer from UI layer. 
>>>>>>> 9c2e22f4ffad504f9035f1dd25818a38c5556b1d
