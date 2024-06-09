//declare college modal object
var collegeModal;

//modal functions
function openCollegeModal() {
    //initialize college modal
    collegeModal = new bootstrap.Modal(document.getElementById('collegeModal'), {
        backdrop: "static"
    });
    collegeModal.show();
}


/* DB transactions */
function connectDB() {
    var xhr = new XMLHttpRequest();
    //initiate request to the server asynchronously (AJAX)
    xhr.open("GET", "CollegeList.aspx/ConnectDB", true);
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

function getCollegeRecords() {
    var xhr = new XMLHttpRequest();
    //initiate request to the server asynchronously (AJAX)
    xhr.open("GET", "CollegeList.aspx/GetCollegeRecords", true);
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
            if (data.CollegeList.length == 0) {
                tableContent = '<tr><td colspan="4" class="text-center">No data on the table</td></tr>';
                document.getElementById('collegeList').innerHTML = tableContent;
            }
            else {
                //for each college record from the CollegeList, inject/append each record to the table body
                for (var i = 0; i < data.CollegeList.length; i++) {
                    tableContent += '<tr><td class="text-center">' + data.CollegeList[i].CollegeID + '</td>' +
                        '<td class="text-center">' + data.CollegeList[i].CollegeName + '</td>' +
                        '<td class="text-center">' + data.CollegeList[i].CollegeCode + '</td>' +
                        '<td class="text-center">' +
                        '<button class="btn  btn-sm" onclick="viewDepartments(' + data.CollegeList[i].CollegeID + ')">View Departments</button>' +
                        '<button class="btn btn-primary btn-sm" onclick="updateCollege(' + data.CollegeList[i].CollegeID + ')">Edit</button>' +
                        '<button class="btn btn-danger btn-sm" onclick="deactivateCollege(' + data.CollegeList[i].CollegeID + ')">Delete</button>' +
                        '</td>' +
                        '</tr>';
                       // '<td class="text-center">For Edit and Delete</td></tr>';
                }
            }
            document.getElementById('collegeList').innerHTML = tableContent;
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

function viewDepartments(CollegeID) {
    alert("viewDepartments  with ID: " + CollegeID);

}
function updateCollege(CollegeID) {
    alert("Edit college with ID: " + CollegeID);
}

function deactivateCollege(CollegeID) {
    alert("Deactivate college with ID: " + CollegeID);
}




function submitCollege() {
    //get data from the form
    var collegeName = document.getElementById('txtCollegeName').value;
    var collegeCode = document.getElementById('txtCollegeCode').value;
    //construct JSON data
    const collegeData = {
        collegeName: collegeName,
        collegeCode: collegeCode
    };
    //setup a POST request
    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'          //set content type to JSON
        },
        body: JSON.stringify({ collegeData: collegeData })      //convert JSON data to a JSON string and set it as a request body
    };
    //send POST request to the server using fetch method
    fetch('CollegeList.aspx/AddCollegeRecord', options)
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
            collegeModal.hide();
            //reload/refresh the college table
            getCollegeRecords();
        })
        .catch(error => {               //error contains response from the server
            //handle any errors that occured during fetch
            console.error('Fetch error: ', error);
            //display the message
            alert(error.d);
        });
}
