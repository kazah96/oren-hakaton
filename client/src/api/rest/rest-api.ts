import restRequest from './restRequest'
import { AxiosRequestConfig } from 'axios'
import defaultApiUrl from './default-url'

const getCurrentUrl = (): string | null => {
  return localStorage.getItem('api_url')
}

const setCurrentUrl = (url: string): void => {
  localStorage.setItem('api_url', url)
}

const currentApiUrl = getCurrentUrl()

console.log('Default api is ' + defaultApiUrl)
console.log('Current api url is ' + currentApiUrl)

if (!currentApiUrl) {
  setCurrentUrl(defaultApiUrl)
}

class RestApi {
  requestUrl: string

  constructor(requestUrl: string) {
    this.requestUrl = requestUrl
  }

  get apiUrl(): string {
    return getCurrentUrl() || defaultApiUrl
  }

  getRestRequest = (request: AxiosRequestConfig) => {
    request.method = 'GET'
    return this.execRestRequest(request)
  }

  postRestRequest = (request: AxiosRequestConfig) => {
    request.method = 'POST'
    return this.execRestRequest(request)
  }

  deleteRestRequest = (request: AxiosRequestConfig) => {
    request.method = 'DELETE'
    return this.execRestRequest(request)
  }

  execRestRequest = (request: AxiosRequestConfig) => {
    request.headers = {
      Accept: 'application/json',
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
      Pragma: 'no-cache',
      Expires: 'Sat, 01 Jan 2000 00:00:00 GMT',
      ...(request.headers || {}),
    }

    // @ts-ignore
    const { apiUrl, url } = request

    request.params = {
      headers: request.headers,
      data: request.data,
      params: request.params,
      // @ts-ignore
      additionalParams: request.additionalParams,
    }

    request.url = `${apiUrl || this.apiUrl}/${url}`

    return restRequest(request.method, request.url, request.params)
  }
}

export default RestApi
