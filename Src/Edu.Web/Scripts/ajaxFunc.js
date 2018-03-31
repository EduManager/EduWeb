function getCampus(ctrlId) {
    $('#' + ctrlId).empty();

    $.get("../Campus/SchoolCampus",
        function (data) {
            var result = JSON.parse(data);
            if (result.code == 200 && result.items.length > 0) {
                for (var index = 0; index < result.items.length; index++) {
                    var item = result.items[index];
                    if (index == 0) {
                        $('#' + ctrlId)
                            .append("<option selected value='" + item.id + "'>" + item.campusName + "</option>");
                    } else {
                        $('#' + ctrlId)
                            .append("<option value='" + item.id + "'>" + item.campusName + "</option>");
                    }
                }
            }
        });
}
function getCourseType(ctrlId) {
    $('#' + ctrlId).empty();
    $.ajax({
        url: "../Course/getAllCourseTypes",
        type: "post",
        //data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = JSON.parse(data);
            if (result.length > 0) {
                for (var index = 0; index < result.length; index++) {
                    var item = result[index];
                    if (index == 0) {
                        $('#' + ctrlId)
                            .append("<option selected value='" + item.id + "'>" + item.courseTypeName + "</option>");
                    } else {
                        $('#' + ctrlId)
                            .append("<option value='" + item.id + "'>" + item.courseTypeName + "</option>");
                    }
                }
            }
        }
    });
}

function getCourseList(ctrlId, courseTypeId) {
    $('#' + ctrlId).empty();
    var model = { CourseTypeId: courseTypeId };
    $.ajax({
        url: "../Course/getCourses",
        type: "post",
        data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = JSON.parse(data);
            if (result.length > 0) {
                for (var index = 0; index < result.length; index++) {
                    var item = result[index];
                    if (index == 0) {
                        $('#' + ctrlId)
                            .append("<option selected value='" + item.id + "'>" + item.courseName + "</option>");
                    } else {
                        $('#' + ctrlId)
                            .append("<option value='" + item.id + "'>" + item.courseName + "</option>");
                    }
                }
            }
        }
    });
}

function getUserList(ctrlId, roleId) {
    $('#' + ctrlId).empty();
    var model = { CourseTypeId: courseTypeId };
    $.ajax({
        url: "../Course/getCourses",
        type: "post",
        data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = JSON.parse(data);
            if (result.length > 0) {
                for (var index = 0; index < result.length; index++) {
                    var item = result[index];
                    if (index == 0) {
                        $('#' + ctrlId)
                            .append("<option selected value='" + item.id + "'>" + item.courseName + "</option>");
                    } else {
                        $('#' + ctrlId)
                            .append("<option value='" + item.id + "'>" + item.courseName + "</option>");
                    }
                }
            }
        }
    });
}