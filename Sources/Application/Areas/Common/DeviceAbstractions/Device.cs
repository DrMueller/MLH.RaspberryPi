﻿using System;
using System.Threading.Tasks;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Exceptions;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Models;
using Mmu.Mlh.RaspberryPi.Infrastructure.PythonAccess.Services;

namespace Mmu.Mlh.RaspberryPi.Areas.Common.DeviceAbstractions
{
    // https://github.com/astro-pi/python-sense-hat/tree/master/sense_hat
    public abstract class Device
    {
        private readonly IPythonExecutor _executor;
        private readonly string _scriptFilePath;

        internal Device(
            IPythonExecutor executor,
            string scriptFilePath)
        {
            _executor = executor;
            _scriptFilePath = scriptFilePath;
        }

        internal async Task<PythonExecutionResult> ExecuteAsync(string methodName, params PythonArgument[] arguments)
        {
            var req = new PythonExecutionRequest(_scriptFilePath, methodName, arguments);
            var res = await _executor.ExecuteAsnc(req);

            res.ErrorMessage.Evaluate(
                whenSome: str =>
                {
                    throw new PythonException(str);
                });

            return res;
        }

        internal void Listen(string methodName, Action<string> callback, params PythonArgument[] arguments)
        {
            var req = new PythonListeningRequest(
                _scriptFilePath,
                methodName,
                callback,
                err => throw new PythonException(err),
                arguments);

            _executor.Listen(req);
        }
    }
}