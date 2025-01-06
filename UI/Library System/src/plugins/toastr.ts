import toastr from 'toastr'
import 'toastr/build/toastr.min.css'

toastr.options = {
  closeButton: true,
  progressBar: true,
  positionClass: 'toast-top-center',
  timeOut: 5000,
}

export default toastr
