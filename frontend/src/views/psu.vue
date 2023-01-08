<template>
  <div class="data">{{ psu1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ psu2 }}
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
    const { data: psu1 } = useSWRV('https://localhost:7233/PowerSupply/1', fetcher)
    const { data: psu2 } = useSWRV('https://localhost:7233/PowerSupply/2', fetcher)
 
    return {
      psu1, psu2
    }
  },
}
</script>
