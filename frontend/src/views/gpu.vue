<template>
  <div class="data">{{ gpu1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ gpu2 }}
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
    const { data: gpu1 } = useSWRV('https://localhost:7233/GraphicsCard/3', fetcher)
    const { data: gpu2 } = useSWRV('https://localhost:7233/GraphicsCard/4', fetcher)
 
    return {
      gpu1,gpu2
    }
  },
}
</script>
