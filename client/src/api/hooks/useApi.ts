interface Props {
  api: new (requestUrl?: string) => any
  requestUrl?: string
}

export default (props: Props) => {
  const { api, requestUrl } = props
  const Api = api

  return new Api(requestUrl)
}
