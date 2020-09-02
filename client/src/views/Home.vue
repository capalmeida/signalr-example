<template>
  <div class="home">
    <TaskBar />
  </div>
</template>

<script>
// @ is an alias to /src
import TaskBar from '@/components/TaskBar.vue'

export default {
  name: 'Home',
  components: {
    TaskBar
  }
}
</script>
