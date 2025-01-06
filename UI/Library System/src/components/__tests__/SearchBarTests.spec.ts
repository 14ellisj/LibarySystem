import { describe, it, expect, vi, beforeAll } from 'vitest'

import { mount } from '@vue/test-utils'
import SearchBar from '../HomeView/SearchBar.vue'
import { createPinia, setActivePinia } from 'pinia'
import { SearchType } from '@/models/searchType'

describe('SearchBar', () => {

  beforeAll(() => {
    setActivePinia(createPinia());
  })

  it('Renders properly', () => {
    const wrapper = mount(SearchBar)

    expect(wrapper.find('.search-container').exists()).toBe(true)
  })

  it('Updates query on input', () => {
    const expectedValue = 'Test'
    const wrapper = mount(SearchBar)
    const input = wrapper.find('input[type="text"]')

    input.setValue(expectedValue)

    expect(wrapper.vm.query).toBe(expectedValue)
  })

  it('Updates search type on change', () => {
    const wrapper = mount(SearchBar)
    const initialSearchType = wrapper.vm.searchType
    const nextSearchType = initialSearchType + 1;

    const select = wrapper.find('select')
    select.setValue(nextSearchType)

    expect(wrapper.vm.searchType).not.toBe(initialSearchType)
    expect(wrapper.vm.searchType).toBe(nextSearchType)
  })

  it('Searches when the user presses enter in the search bar', () => {
    const wrapper = mount(SearchBar)
    const submitMock = vi.spyOn(wrapper.vm, 'submit')

    const input = wrapper.find('input[type="text"]')
    input.trigger('keypress', { key: 'Enter' })

    expect(submitMock).toHaveBeenCalled()
  })
})
