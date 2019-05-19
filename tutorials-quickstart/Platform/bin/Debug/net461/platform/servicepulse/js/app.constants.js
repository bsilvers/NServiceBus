;(function(window, angular, undefined) {
    'use strict';

    window.config = {
        default_route: '/dashboard',
        service_control_url: 'http://localhost:49200/api/',
        monitoring_urls: ['http://localhost:49202/']
    };

    angular.module('sc')
        .constant('version', '1.19.0')
        .constant('showPendingRetry', false)
        .constant('scConfig', window.config);

}(window, window.angular));
