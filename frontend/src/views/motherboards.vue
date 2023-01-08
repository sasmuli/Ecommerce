<template>
  <div class="data">{{ motherboard1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ motherboard2 }}
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
    const { data: motherboard1} = useSWRV('https://localhost:7233/Motherboard/1', fetcher)
    const { data: motherboard2 } = useSWRV('https://localhost:7233/Motherboard/2', fetcher)
 
    return {
      motherboard1, motherboard2
    }
  },
}
</script>
