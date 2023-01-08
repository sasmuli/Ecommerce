<template>
  <div class="data">{{ headset1 }}
    <div>
      <button class="buybtn">Buy</button>
    </div>
  </div>
  <div class="data">{{ headset2 }}
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
    const { data: headset1 } = useSWRV('https://localhost:7233/Headset/1', fetcher)
    const { data: headset2 } = useSWRV('https://localhost:7233/Headset/3', fetcher)
 
    return {
      headset1,headset2
    }
  },
}
</script>

