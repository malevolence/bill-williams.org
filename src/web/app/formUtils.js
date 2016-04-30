(function(window, $, undefined) {
	'use strict';

	var BW = window.BW = window.BW || {};

	BW.formUtils = {};

	BW.formUtils.hijaxForm = function(selector, cb) {
        var form$ = $(selector);

        form$.on('submit', function (e) {
            e.preventDefault();

            var url = form$.attr('action');
            var data = form$.serialize();

            return $.post(url, data).then(cb);
        });
	};

    BW.formUtils.showAlert = function (opts) {
        var defaults = {
            css: 'alert-info',
            msg: 'Default Message'
        };

        var settings = $.extend({}, defaults, opts);

        $('<div></div>', {
            'class': 'fade in alert ' + settings.css,
            html: settings.msg
        }).append($('<button />', {
            html: '&times;',
            'type': 'button',
            'class': 'close',
            'data-dismiss': 'alert'
        })).insertBefore('#main-row');
    };

	BW.formUtils.registerHelpers = function() {
		console.log('Registering helpers...');
	};

	BW.formUtils.init = function() {
		BW.formUtils.registerHelpers();
	};

})(window, jQuery);