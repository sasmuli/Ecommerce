<template>
  <div class="data">{{ cpu1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ cpu2 }}
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
    const { data: cpu1} = useSWRV('https://localhost:7233/Processor/1', fetcher)
    const { data: cpu2 } = useSWRV('https://localhost:7233/Processor/2', fetcher)
 
    return {
      cpu1, cpu2
    }
  },
}
</script>
