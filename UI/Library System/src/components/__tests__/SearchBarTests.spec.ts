import { describe, it, expect, beforeAll, vi } from 'vitest'

import { mount } from '@vue/test-utils'
import SearchBar from '../HomeView/SearchBar.vue'

describe('SearchBar', () => {
  it('Renders properly', () => {
    const wrapper = mount(SearchBar)

    expect(wrapper.find('.search-container').exists()).toBe(true)
    expect(wrapper.find('.search-select-area').exists()).toBe(true)
    expect(wrapper.find('.search-button-area').exists()).toBe(true)
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

    const select = wrapper.find('select')
    select.setValue('Author')
    expect(wrapper.vm.searchType).toBe('Author')
  })

  it('Searches when the user presses enter in the search bar', () => {
    const wrapper = mount(SearchBar)
    const submitMock = vi.spyOn(wrapper.vm, 'submit')

    const input = wrapper.find('input[type="text"]')
    input.trigger('keypress', { key: 'Enter' })

    expect(submitMock).toHaveBeenCalled()
  })
})
