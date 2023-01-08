<template>
  <div class="data">{{ mouse1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ mouse2 }}
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
    const { data: mouse1 } = useSWRV('https://localhost:7233/Mouse/1', fetcher)
    const { data: mouse2 } = useSWRV('https://localhost:7233/Mouse/2', fetcher)
 
    return {
      mouse1, mouse2
    }
  },
}
</script>
