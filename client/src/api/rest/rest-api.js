import restRequest from './restRequest';

class RestApi {
  constructor(requestUrl) {
    this.requestUrl = requestUrl;
    this.apiUrl = 'https://6f5b6ed9fb0f.ngrok.io'
  }

  getRestRequest = request => {
    request.method = 'GET';
    return this.execRestRequest(request);
  };

  postRestRequest = request => {
    request.method = 'POST';
    return this.execRestRequest(request);
  };

  deleteRestRequest = request => {
    request.method = 'DELETE';
    return this.execRestRequest(request);
  };

  execRestRequest = request => {
    request.headers = {
      Accept: 'application/json',
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
      Pragma: 'no-cache',
      Expires: 'Sat, 01 Jan 2000 00:00:00 GMT',
      ...(request.headers || {})
    };
    const { apiUrl, url } = request;

    request.params = {
      headers: request.headers,
      data: request.data,
      params: request.params,
      additionalParams: request.additionalParams
    };

    request.url = `${apiUrl || this.apiUrl}/${url}`;

    return restRequest(request.method, request.url, request.params);
  };
}

export default RestApi;
