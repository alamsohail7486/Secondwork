

$(document).ready(function () {
    GetAllStudent()

});
function InsertStudent() {
    var studentobj = {
        Name: $("#name").val(),
        Address: $("#address").val(),
        NPhone_no: $("#phone_no").val(),
        Age: $("#age").val(),
        Standard: $("#standard").val(),
        Email_id: $("#email_id").val(),
    }

    $.ajax({
        url: "/Home/InsertStudent",
        type: "POST",
        data: studentobj,
        success: function(result)
        {
            alert("data is succesfully pass");
        }


    });

}
//data inheriate and update from table
function GetAllStudent() {
    $.ajax({
        url: "/Home/GetStudents",
        type: "GET",
        dataType: "Json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td>' + item.Phone_no + '</td>';
                html += '<td>' + item.Age + '</td>';
                html += '<td>' + item.Standard + '</td>';
                html += '<td>' + item.Email_id + '</td>';
                html += '<td><button class="btn btn-danger" onclick="DeleteStudent(' + item.Id + ')" > Delete</button >';

            })
            $(".students").html(html);
        }
    })
}
function DeleteStudent(Id) {
    alert(Id);
    $.ajax({
        url: "/Home/DeleteStudent?Id=" + Id,
        type: "POST",
        success: function (result) {
            alert('Data is successfully deleted');
        },
        error: function (result) {
            alert('Error in deleting data');
        }


    })
}
    
