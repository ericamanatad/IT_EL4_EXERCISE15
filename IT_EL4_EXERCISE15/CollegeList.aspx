<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CollegeList.aspx.cs" Inherits="IT_EL4_EXERCISE15.CollegeList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Lib/Bootstrap/5.3.3/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/css/default.css" />
    <script type="text/javascript" src="Lib/Bootstrap/5.3.3/js/bootstrap.min.js"></script>
     <script type="text/javascript" src="Scripts/js/collegeList.js"></script>
    <title>College List</title>
</head>
<body onload="getCollegeRecords()">
    <div class="container">
        <div>
        <h1 class =" text-center">College List</h1>
        <div id ="buttonsPanel">
            <button class="btn btn-secondary" type="button" onclick="connectDB()">Connect DB</button>
            <button class="btn btn-primary" type="button" onclick="openCollegeModal()">+Add</button>
        </div>
        </br>
        <table class="table table-bordered table-striped table-hover">
            <thead  class="bg-success text-white">
                <tr>
                    <th class="text-center">College ID</th>
                    <th class="text-center">College Name</th>
                    <th class="text-center">College Code</th>
                    <th class="text-center">Actions</th>
                </tr>
            </thead>
            <tbody id="collegeList">
            </tbody>
        </table>      
    </div>
    </div>
        <!-- College Form -->
        <div class="modal fade" id="collegeModal" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                <!-- modal header -->
                <div class="modal-header">
                    <h4 class="modal-title">Add College</h4>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <!-- modal body -->
                <div class="modal-body">
                    <form id="form1" runat="server">
                        <div class="row">
                            <div class="col-sm-12">
                                <label class="col-form-label">College Name: </label>
                                <input type="text" class="form-control" id="txtCollegeName" placeholder="Input College Name" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <label class="col-form-label">College Code: </label>
                                <input type="text" class="form-control" id="txtCollegeCode" placeholder="Input College Code" />
                            </div>
                        </div>
                    </form>
                </div>
                <!-- modal footer -->
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" onclick="submitCollege()">Submit</button>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                </div>
            </div>   
           </div>
        </div>
</body>
</html>
