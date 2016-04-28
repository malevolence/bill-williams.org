(function(window, $, undefined) {
	'use strict';

	var BW = window.BW = window.BW || {};

	BW.formUtils = {};
	BW.formUtils.registerHelpers = function() {
		console.log('Registering helpers...');
	};

	BW.formUtils.init = function() {
		BW.formUtils.registerHelpers();
	};

})(window, jQuery);