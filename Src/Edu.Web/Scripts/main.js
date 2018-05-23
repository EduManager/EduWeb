var widgetToggle = function () {
    $(".actions > .glyphicon-chevron-up").click(function () {
        $(this).parent().parent().next().slideToggle("fast"), $(this).toggleClass("glyphicon-chevron-up glyphicon-chevron-down")
    });
};
// 对Date的扩展，将 Date 转化为指定格式的String
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)
// 例子：
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423
// (new Date()).Format("yyyy-M-d h:m:s.S")   ==> 2006-7-2 8:9:4.18
Date.prototype.Format = function (fmt) { //author: meizz
    var o = {
        "M+": this.getMonth() + 1, //月份
        "d+": this.getDate(), //日
        "h+": this.getHours(), //小时
        "m+": this.getMinutes(), //分
        "s+": this.getSeconds(), //秒
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度
        "S": this.getMilliseconds() //毫秒
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};
function getObjectURL(file) {
    var url = null;
    // 下面函数执行的效果是一样的，只是需要针对不同的浏览器执行不同的 js 函数而已  
    if (window.createObjectURL != undefined) { // basic  
        url = window.createObjectURL(file);
    } else if (window.URL != undefined) { // mozilla(firefox)  
        url = window.URL.createObjectURL(file);
    } else if (window.webkitURL != undefined) { // webkit or chrome  
        url = window.webkitURL.createObjectURL(file);
    }
    return url;
}
function changeDiscount() {
    var desc = $("#selectDiscount").val();
    if (desc == '0') {
        $("#lblDiscountType").addClass("hidden");
        $("#txtDiscount").addClass("hidden");
        $("#selectDiscountValue").addClass("hidden");
        discountvalue = 1;
    }
    else if (desc == '1') {
        $("#txtDiscount").addClass("hidden");
        $("#lblDiscountType").removeClass("hidden");
        $("#selectDiscountValue").removeClass("hidden");
        $("#lblDiscountType").text("折");
        discountvalue = $("#selectDiscountValue").val();
    }
    else if (desc == '2') {
        $("#selectDiscountValue").addClass("hidden");
        $("#lblDiscountType").removeClass("hidden");
        $("#txtDiscount").removeClass("hidden");
        $("#lblDiscountType").text("元");
        discountvalue = $("#txtDiscount").val();
    }
    calcTuition();
}