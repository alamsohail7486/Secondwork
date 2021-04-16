
$(document).ready(function () {
    CustomerList();
});


function Insertcustomer() {
    var customerobj = {
        Name: $("#name").val(),
        Age: $("#age").val(),
        Contact_no: $("#contact_no").val(),
        Address: $("#address").val(),
        Salary: $("#salary").val(),
        Hobby: $("#hobby").val()
    }

    $.ajax({
      
        url: "/Home/InsertCustomer",
        type: "POST",
        data: customerobj,
        success: function (result) {
            alert(result);
            alert("data is successfully pass");
        },
        error: function (result) {
            alert("Error in inserting data");

        }
        
    });
}


//data inheriate and update from table for customers
function CustomerList() {
    $.ajax({
        url: "/Home/GetCustomers",
        type: "GET",
        dataType: "Json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Age + '</td>';
                html += '<td>' + item.Contact_no + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td>' + item.Salary + '</td>';
                html += '<td>' + item.Hobby + '</td>';
                html += '<td><input type="button"  class="btn btn-primary" value="Delete" /></td>';
                html += '</tr>';

            })
            $(".customers").html(html);
        }
    })
}
function DeleteCustomer(Id) {
    alert(Id);
    $.ajax({
        url: "/Home/DeleteCustomer?Id=" + Id,
        type: "POST",
        success: function (result) {
            alert("Data is successfully deleted");
        },
        error: function (result) {
            alert("Error message is showing on data");
        }
    })
}