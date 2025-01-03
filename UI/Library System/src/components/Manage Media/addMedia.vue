<script lang="ts">
import { defineComponent, ref, computed } from 'vue'
import { useMediaStore } from '../../stores/media'

export default defineComponent({
  name: 'Add Media',
  setup() {
    const mediaStore = useMediaStore()
    const media = ref(mediaStore.media)
    const isAddingNewAuthor = ref(false)
    const newAuthorFirstName = ref('')
    const newAuthorLastName = ref('')

    // Compute unique authors
    const uniqueAuthors = computed(() => {
      const seen = new Set()
      return media.value.filter((item) => {
        const fullName = `${item.author.first_name} ${item.author.last_name}`
        if (seen.has(fullName)) {
          return false
        }
        seen.add(fullName)
        return true
      })
    })

    // Function to convert image file to base64
    const handleImageToBase64 = (file: File): Promise<string | ArrayBuffer | null> => {
      return new Promise((resolve, reject) => {
        const reader = new FileReader()
        reader.onload = () => resolve(reader.result)
        reader.onerror = () => reject(reader.error)
        reader.readAsDataURL(file)
      })
    }

    // Handle form submission
    const handleSubmit = async (event: Event) => {
      event.preventDefault()
      const formData = new FormData(event.target as HTMLFormElement)

      // Convert the uploaded image to base64
      const imageFile = formData.get('image') as File
      let imageBase64 = null
      if (imageFile) {
        try {
          imageBase64 = await handleImageToBase64(imageFile)
        } catch (error) {
          console.error('Error converting image to base64:', error)
        }
      }

      // Collect the author data
      const author = isAddingNewAuthor.value
        ? {
            first_name: newAuthorFirstName.value,
            last_name: newAuthorLastName.value,
          }
        : formData.get('author')

      const newMedia = {
        mediaName: formData.get('media-name'),
        mediaType: formData.get('media-type'),
        mediaGenre: formData.get('media-genre'),
        description: formData.get('description'),
        author: author,
        length: formData.get('length'),
        image: imageBase64,
        rating: formData.get('rating'),
      }
      console.log('Form Data Submitted:', newMedia)
      // Add logic to save `newMedia` to the store or send to a backend.
    }

    // Handle author selection
    const handleAuthorChange = (event: Event) => {
      const value = (event.target as HTMLSelectElement).value
      isAddingNewAuthor.value = value === '+ Add New'
    }

    return {
      mediaStore,
      media,
      uniqueAuthors, // Expose computed property
      isAddingNewAuthor,
      newAuthorFirstName,
      newAuthorLastName,
      handleSubmit,
      handleAuthorChange,
    }
  }
})
</script>

<template>
  <div class="form-container">
    <h1>Media Input Form</h1>
    <form @submit="handleSubmit">
        <div>
            <button class="back-button" @click="$router.push('/change')">Change Quantity</button>
        </div>
      <div class="form-group">
        <label for="media-name">Media Name:</label>
        <input type="text" id="media-name" name="media-name" placeholder="Enter media name" required />
      </div>
      <div class="form-group">
        <label for="media-type">Type:</label>
        <select id="media-type" name="media-type" required>
          <option value="">Select Type</option>
          <option value="1">Audio-Book</option>
          <option value="2">Book</option>
          <option value="3">DVD</option>
        </select>
      </div>
      <div class="form-group">
        <label for="media-genre">Genre:</label>
        <select id="media-genre" name="media-genre" required>
          <option value="">Select Genre</option>
          <option value="0">Fantasy</option>
          <option value="1">Romance</option>
          <option value="2">Horror</option>
        </select>
      </div>
      <div class="form-group">
        <label for="description">Description:</label>
        <textarea id="description" name="description" placeholder="Enter a brief description" required></textarea>
      </div>
      <div class="form-group">
        <label for="author">Author/Creator:</label>
        <select name="author" @change="handleAuthorChange" required>
          <option value="">Select Author</option>
          <option
            v-for="item in uniqueAuthors"
            :key="item.id"
            :value="item.author.first_name + ' ' + item.author.last_name">
            {{ item.author.first_name }} {{ item.author.last_name }}
          </option>
          <option value="+ Add New">+ Add New</option>
        </select>
      </div>
      <div class="form-group" v-if="isAddingNewAuthor">
        <label for="new-author-first-name">First Name:</label>
        <input
          type="text"
          id="new-author-first-name"
          v-model="newAuthorFirstName"
          placeholder="Enter first name"
          required
        />
      </div>
      <div class="form-group" v-if="isAddingNewAuthor">
        <label for="new-author-last-name">Last Name:</label>
        <input
          type="text"
          id="new-author-last-name"
          v-model="newAuthorLastName"
          placeholder="Enter last name"
          required
        />
      </div>
      <div class="form-group">
        <label for="length">Length (e.g., pages, minutes):</label>
        <input type="text" id="length" name="length" placeholder="Enter length" required />
      </div>
      <div class="form-group">
        <label for="rating">Rating:</label>
        <select id="rating" name="rating" required>
          <option value="">Select Rating</option>
          <option value="3.8">3.8</option>
          <option value="3.9">3.9</option>
          <option value="4.0">4.0</option>
          <option value="4.1">4.1</option>
          <option value="4.2">4.2</option>
          <option value="4.3">4.3</option>
          <option value="4.4">4.4</option>
          <option value="4.5">4.5</option>
          <option value="4.6">4.6</option>
          <option value="4.7">4.7</option>
          <option value="4.8">4.8</option>
          <option value="4.9">4.9</option>
          <option value="5.0">5.0</option>
        </select>
      </div>
      <div class="form-group">
        <label for="image">Upload Image:</label>
        <input type="file" id="image" name="image" accept="image/*" />
      </div>
      <div class="form-group">
        <button type="submit">Submit</button>
      </div>
      <button class="back-button" type="button" @click="$router.push('/manage')" style="margin-top: 10px; background-color: #6c757d;">
          Back
        </button>
    </form>
  </div>
</template>



<style scoped>
    body {
            font-family: Arial, sans-serif;
            margin-top: 100px;
            margin-bottom: 100px;
            padding: 0;
            background-color: #f4f4f9;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .form-container {
            background-color: #fff;
            padding-top: 20px;
            padding-left: 50px;
            padding-right: 50px;
            padding-bottom: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            max-width: 400px;
            width: 100%;
        }

        .form-container h1 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }

        .form-group input, .form-group select, .form-group textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }

        .form-group textarea {
            resize: none;
            height: 100px;
        }

        .form-group button {
            width: 100%;
            padding: 10px;
            background-color: var(--secondary-color);
            color: white;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }   
        .back-button {
    background-color: var(--secondary-color);
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 5px;
    cursor: pointer;
    margin-bottom: 20px;
    font-size: 16px;
  }  
</style>