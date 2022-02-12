$(document).ready(function () {
    $("#run-tests-btn").click(CheckSolution);
});

function LoadSolution(inputId) {
    var input = document.getElementById(inputId);
    var formData = new FormData();
    formData.append("studentResultId", StudentTaskResultId);
    formData.append("studentFile", input.files[0]);

    var request = new XMLHttpRequest();
    request.open("POST", "/Students/LoadSolution");
    request.send(formData);

    //$.ajax({
    //    url: "/Students/LoadSolution",
    //    data: formData,
    //    processData: false,
    //    type: 'POST',
    //    success: function (data) {
    //        alert(data);
    //    }
    //});
}

function CheckSolution() {
    $.post({
        url: "/Students/CheckSolution?studentResultId=" + StudentTaskResultId,
        //success: function (data) {
        //    var passedTestsCount = 0;
        //    for (var i = 0; i < data.data.length; i++) {
        //        $(".testLabel[data-id='" + data.data[i].testId + "']").html(data.data[i].testTitle + "............" + data.data[i].state.title);
        //        if (data.data[i].state.title == "Пройден")
        //            passedTestsCount++;
        //    }
        //    $("#passedTestsCountLabel").html(passedTestsCount);
        //}
    });
}