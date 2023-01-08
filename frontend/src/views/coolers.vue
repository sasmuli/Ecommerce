<template>
  <div class="data">{{ cooler1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ cooler2 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ cooler3 }}
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
    const { data: cooler1 } = useSWRV('https://localhost:7233/Cooler/1', fetcher)
    const { data: cooler2 } = useSWRV('https://localhost:7233/Cooler/10', fetcher)
    const { data: cooler3 } = useSWRV('https://localhost:7233/Cooler/11', fetcher)
 
    return {
      cooler1,cooler2, cooler3
    }
  },
}
</script>

