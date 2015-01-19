
//全局对话框
//jiangyongsheng 20141221

var wrapper = {};
//显示对话框,远程加载
wrapper.showModalDialog = function (url, width, height) {
    top.dialog({
        width: width,
        height: height,
        title: '加载中...',
        url: url,
        onclose: function () {
            //接收对方返回的数据
            var resultUrl = this.returnValue;
            if (resultUrl && resultUrl != null) {
                window.location.href = resultUrl;;
            }
        }
    }).showModal();
}
//普通对话框
wrapper.basicDialog = function (title, content) {
    var d = dialog({
        title: title,
        content: content
    });
    d.show();
}
//普通模态对话框
wrapper.basicModalDialog = function (title, content) {
    var d = dialog({
        title: title,
        content: content
    });
    d.showModal();
}
//带确定与取消按钮对话框
wrapper.buttonDialog = function (title, content, funcSuc) {
    var d = dialog({
        title: title,
        content: content,
        okValue: '确定',
        ok: function () {
            this.title('提交中…');
            funcSuc();
            return true;
        },
        cancelValue: '取消',
        cancel: function () { }
    });
    d.show();
}
//对话框将在两秒内关闭
wrapper.timeoutDialog = function (content) {
    var d = dialog({
        content: content
    });
    d.show();
    setTimeout(function () {
        d.close().remove();
    }, 2000);
};
//对话框将在两秒内关闭,模态
wrapper.timeoutModalDialog = function (content) {
    var d = dialog({
        content: content
    });
    d.showModal();
    setTimeout(function () {
        d.close().remove();
    }, 2000);
};
//对话框将在两秒内关闭，错误提示
wrapper.timeoutErrDialog = function (content) {
    wrapper.timeoutDialog('<div style=" text-align:center; font-size:16px"><i class="glyphicon glyphicon-remove-sign" style="top:4px;color:#ff0000; font-size: 20px;"></i>&nbsp;' + content + '</div>');
};
//对话框将在两秒内关闭，正确提示
wrapper.timeoutOkDialog = function (content) {
    wrapper.timeoutDialog('<div style=" text-align:center; font-size:16px"><i class="glyphicon glyphicon-ok-sign" style="top:3px;color:#04ac5a; font-size: 20px;"></i>&nbsp;' + content + '</div>');
};

//对话框将在两秒内关闭，模态，错误提示
wrapper.timeoutErrModalDialog = function (content) {
    wrapper.timeoutModalDialog('<div style=" text-align:center; font-size:16px"><i class="glyphicon glyphicon-remove-sign" style="top:4px;color:#ff0000; font-size: 20px;"></i>&nbsp;' + content + '</div>');
};
//对话框将在两秒内关闭，模态，正确提示
wrapper.timeoutOkModalDialog = function (content) {
    wrapper.timeoutModalDialog('<div style=" text-align:center; font-size:16px"><i class="glyphicon glyphicon-ok-sign" style="top:3px;color:#04ac5a; font-size: 20px;"></i>&nbsp;' + content + '</div>');
};