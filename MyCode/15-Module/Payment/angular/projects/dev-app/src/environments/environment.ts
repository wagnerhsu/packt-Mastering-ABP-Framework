import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Payment',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44369',
    redirectUri: baseUrl,
    clientId: 'Payment_App',
    responseType: 'code',
    scope: 'offline_access Payment role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44369',
      rootNamespace: 'Payment',
    },
    Payment: {
      url: 'https://localhost:44376',
      rootNamespace: 'Payment',
    },
  },
} as Environment;
