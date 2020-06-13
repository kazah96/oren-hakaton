export default (props = {}) => {
  const { api, requestUrl } = props
  const Api = api

  return new Api(requestUrl)
}
