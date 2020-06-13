import axios, { AxiosRequestConfig } from 'axios'

export default (method: any, urlRelativeToApp: any, params: any) => {
  const url = urlRelativeToApp

  let config: AxiosRequestConfig = { method, url }

  const returnFullResponse = params && params.returnFullResponse

  if (params) {
    if (params.additionalParams) {
      config = Object.assign(config, params.additionalParams) // добавляем доп параметры для axios'а
    }
    if (params.data) {
      config.data = params.data
    }
    if (params.params) {
      config.params = params.params
    }
    if (params.headers) {
      config.headers = params.headers
    }
    if (params.responseType) {
      config.responseType = params.responseType
    }
  }

  // @ts-ignore
  config.crossDomain = true

  return axios.request(config).then((response) => (returnFullResponse ? response : response.data))
}
