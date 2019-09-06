import { stringify } from 'querystring';

export class Api {
    static async getData(method,endpoint, params) {
      
      let headers = new Headers({
        Accept: 'application/json',
        'Content-Type': 'application/json',
      });
      
      let uri = '/' + endpoint;
      let response;

      if (method === 'GET') {
        if (params !== undefined) {
          uri += '?' + stringify(params);
        }
        response = await fetch(uri, { method: method, headers });
      } else {
        response = await fetch(uri, {
          method: method,
          headers,
          body: JSON.stringify(params),
        });
      }

      try {
        return await response.json();
      } catch (e) {
        return {};
      }
    }
}
