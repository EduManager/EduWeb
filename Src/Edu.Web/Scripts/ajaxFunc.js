function getCampus(ctrlId) {
    $('#' + ctrlId).empty();
    $('#' + ctrlId).append("<option disabled selected value='-1'></option>");
    $.get("../Campus/SchoolCampus",
        function (data) {
            var result = JSON.parse(data);
            if (result.code == 200 && result.items.length > 0) {
                for (var index = 0; index < result.items.length; index++) {
                    var item = result.items[index];
                    if (index == 0) {
                        $('#' + ctrlId)
                            .append("<option value='" + item.id + "'>" + item.campusName + "</option>");
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
    $('#' + ctrlId).append("<option disabled selected value='-1'></option>");
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
                            .append("<option value='" + item.id + "'>" + item.courseTypeName + "</option>");
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

function getClassByCourse(courseId, ctrlId) {
    $('#' + ctrlId).empty();
    var model = { 'courseId': courseId };
    $.ajax({
        url: "../Classes/getClassByCourseId",
        type: "post",
        data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = JSON.parse(data);
            if (result.length > 0) {
                for (var index = 0; index < result.length; index++) {
                    var item = result[index];
                    $('#' + ctrlId)
                        .append("<option value='" + item.id + "'>" + item.schoolRegionName + "|" + item.name + "|" + item.teacher + "|" + item.unitPrice + "元/" + item.feeType + "</option>");
                }
            }
        }
    });
}

function getBookFeeByCourse(courseId) {
    var model = { 'courseId': courseId };
    $.ajax({
        url: "../Bookfee/getBookFeeByCourse",
        type: "post",
        data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var result = JSON.parse(data);
            return result;
        }
    });
}

/*时间格式转换*/
function ChangeDateFormat(cellval) {
    var date = new Date(parseInt(cellval.replace("/Date(", "").replace(")/", ""), 10));
    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
    return date.getFullYear() + "-" + month + "-" + currentDate;
}
