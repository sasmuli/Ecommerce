<template>
  <div class="data">{{ ram1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ ram2 }}
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
    const { data: ram1 } = useSWRV('https://localhost:7233/Ram/1', fetcher)
    const { data: ram2 } = useSWRV('https://localhost:7233/Ram/2', fetcher)
 
    return {
      ram1, ram2
    }
  },
}
</script>
