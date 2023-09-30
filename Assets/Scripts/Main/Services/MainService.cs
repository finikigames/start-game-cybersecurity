using Global.Flow;

namespace Main.Services {
    public class MainService {
        private readonly FlowService _service;

        public MainService(FlowService service) {
            _service = service;
        }
    }
}