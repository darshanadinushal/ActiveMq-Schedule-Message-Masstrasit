using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sample.Application.Lib.Model.Domain;
using Sample.Application.Publisher.Infra.Contract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Publisher.Infra.Service
{
    public class ProducerService : IProducerService
    {
        private readonly ILogger<ProducerService> _logger;
        private readonly IMessageScheduler _messageScheduler;

        public ProducerService(ILogger<ProducerService> logger, IMessageScheduler messageScheduler)
        {
            _logger = logger;
            _messageScheduler = messageScheduler;
        }

        public async Task Publish(EmailMessage request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation($"Start ActiveMQProvider SendMessage , message:{JsonConvert.SerializeObject(request)}");
                string destinationQueue = $"queue:EmailNotification";
                await _messageScheduler.ScheduleSend(new Uri(destinationQueue), request.ScheduledTime, 
                    request , cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("SendMessage Error " + ex.Message);
                throw;
            }
        }
    }
}
