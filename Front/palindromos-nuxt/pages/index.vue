<template>
  <div class="container flex flex-col">
    <div class="text-2xl">
      Introduzca la cadena de caracteres:
    </div>
    <div class="flex flex-row">
      <input type="text" v-model="cadena"
      @keyup.enter="enviarCadena()"
      class="text-xl px-2 py-2 placeholder-blueGray-300 text-blueGray-600 relative bg-white bg-white rounded text-sm border-0 shadow outline-none focus:outline-none focus:ring w-full"
      >
      <button
        @click="enviarCadena()"
        class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded m-1"
      >
        Comprobar
      </button>
    </div>
    <div class="text-2xl">
      Palíndromos contenidos:
      <div>
        <ul v-for="item in palindromos.palindromosContenidos" :key="item">
          {{item}}
        </ul>
      </div>
    </div>
    <div class="text-2xl">
      Palíndromos totales:
      <div>
        {{palindromos.palindromosTotales}}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      cadena: "",
      palindromos: {
        palindromosContenidos: [],
        palindromosTotales: 0
      }
    }
  },
  methods: {
    enviarCadena() {
      this.$axios.get("https://localhost:5001/Palindromos/"+this.cadena).then(response => {
        this.palindromos = response.data;
      })
    }
  }
}
</script>

<style>
/* Sample `apply` at-rules with Tailwind CSS
.container {
@apply min-h-screen flex justify-center items-center text-center mx-auto;
}
*/
.container {
  margin: 0 auto;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.title {
  font-family:
    'Quicksand',
    'Source Sans Pro',
    -apple-system,
    BlinkMacSystemFont,
    'Segoe UI',
    Roboto,
    'Helvetica Neue',
    Arial,
    sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
</style>
