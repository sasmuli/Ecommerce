<template>
  <div class="data">{{ monitor1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ monitor2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
</template>

<script>
import useSWRV from 'swrv'

const fetcher = function(url){
  return fetch(url).then(r => r.json())
}

export default {
  name: 'App',
  setup() {
    const { data: monitor1 } = useSWRV('https://localhost:7233/Monitor/1', fetcher)
    const { data: monitor2 } = useSWRV('https://localhost:7233/Monitor/2', fetcher)
 
    return {
      monitor1, monitor2
    }
  },
}
</script>
