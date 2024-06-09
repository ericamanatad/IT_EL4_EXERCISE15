//declare college modal object
var departmentModal;

//modal functions
function openDepartmentModal() {
    //initialize college modal
    departmentModal = new bootstrap.Modal(document.getElementById('departmentModal'), {
        backdrop: "static"
    });
    departmentModal.show();
}


/* DB transactions */
function connectDB() {
    var xhr = new XMLHttpRequest();
    //initiate request to the server asynchronously (AJAX)
    xhr.open("GET", "DepartmentList.aspx/ConnectDB", true);
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    //send the request
    xhr.send();
    //onreadystatechange callback function
    xhr.onreadystatechange = function () {
        //check if server has completed the request
        if (xhr.readyState === 4 && xhr.status === 200) {
            //get server response
            var response = JSON.parse(xhr.responseText);
            console.log('Server response: ' + response.d);
            alert("DB connection status: " + response.d);
        }
    }
    //onerror callback function
    xhr.onerror = function () {
        //get server response
        var response = JSON.parse(xhr.responseText);
        console.log('Server response: ' + response.d);
        alert("DB connection status: " + response.d);
    }
}

function getDepartmentRecords() {
    var xhr = new XMLHttpRequest();
    //initiate request to the server asynchronously (AJAX)
    xhr.open("GET", "DepartmentList.aspx/GetDepartmentRecords", true);
    xhr.setRequestHeader("Content-Type", "application/json; charset=utf-8");
    //send the request
    xhr.send();
    //onreadystatechange callback function
    xhr.onreadystatechange = function () {
        //check if server has completed the request
        if (xhr.readyState === 4 && xhr.status === 200) {
            //get server response
            var response = JSON.parse(xhr.responseText);
            var data = response.d;
            console.log('Server data: ', data);
            alert("Message: " + data.Message);
            var tableContent = '';
            if (data.DepartmentList.length == 0) {
                tableContent = '<tr><td colspan="4" class="text-center">No data on the table</td></tr>';
                document.getElementById('departmentList').innerHTML = tableContent;
            }
            else {
                //for each department record from the DepartmentList, inject/append each record to the table body
                for (var i = 0; i < data.DepartmentList.length; i++) {
                    tableContent += '<tr><td class="text-center">' + data.DepartmentList[i].DepartmentID + '</td>' +
                        '<td class="text-center">' + data.DepartmentList[i].DepartmentName + '</td>' +
                        '<td class="text-center">' + data.DepartmentList[i].DepartmentName + '</td>' +
                        '<td class="text-center">' +
                        '<button class="btn btn-primary btn-sm" onclick="updateDepartment(' + data.DepartmentList[i].DepartmentID + ')">Edit</button>' +
                        '<button class="btn btn-danger btn-sm" onclick="deactivateDepartment(' + data.DepartmentList[i].DepartmentID + ')">Delete</button>' +
                        '</td>' +
                        '</tr>';
                    // '<td class="text-center">For Edit and Delete</td></tr>';
                }
            }
            document.getElementById('departmentList').innerHTML = tableContent;
        }
    }
    //onerror callback function
    xhr.onerror = function () {
        //get server response
        var response = JSON.parse(xhr.responseText);
        var data = response.d;
        console.log('Server data: ', data);
        alert("Message: " + data.Message);
    }
}

function viewDepartment(DepartmentID) {
    alert("viewDepartments  with ID: " + DepartmentID);

}
function updateDepartment(DepartmentID) {
    alert("Edit college with ID: " + DepartmentID);
}

function deactivateDepartment(DepartmentID) {
    alert("Deactivate college with ID: " + DepartmentID);
}




function submitDepartment() {
    //get data from the form
    var departmentName = document.getElementById('txtDepartmentName').value;
    var departmentCode = document.getElementById('txtDepartmentCode').value;
    //construct JSON data
    const departmentData = {
        departmentName: departmentName,
        departmentName: departmentCode
    };
    //setup a POST request
    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'          //set content type to JSON
        },
        body: JSON.stringify({ departmentData: departmentData })      //convert JSON data to a JSON string and set it as a request body
    };
    //send POST request to the server using fetch method
    fetch('DepartmentList.aspx/AddDepartmentRecord', options)
        .then(response => {             //response contains response from the server
            //get server response
            console.log('Server response: ', response);
            //parse the response as JSON
            return response.json();
        })
        .then(data => {                 //contains converted response as JSON
            //handle the JSON data
            console.log(data);
            //display the message
            alert(data.d);
            //close modal
            departmentModal.hide();
            //reload/refresh the college table
            getDepartmentRecords();
        })
        .catch(error => {               //error contains response from the server
            //handle any errors that occured during fetch
            console.error('Fetch error: ', error);
            //display the message
            alert(error.d);
        });
}
