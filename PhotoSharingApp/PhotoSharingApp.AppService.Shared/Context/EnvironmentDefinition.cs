//-----------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using System.Web.Configuration;

namespace PhotoSharingApp.AppService.Shared.Context
{
    /// <summary>
    /// The service environment definition.
    /// </summary>
    public class EnvironmentDefinition : EnvironmentDefinitionBase
    {
        private DocumentDbStorage _documentDbStorage;

        /// <summary>
        /// The DocumentDB database.
        /// </summary>
        public override DocumentDbStorage DocumentDbStorage
        {
            get
            {
                if (_documentDbStorage == null)
                {
                    _documentDbStorage = new DocumentDbStorage
                    {
                        // We have supplied a default DatabaseId and CollectionId here, feel free to configure your own.
                        // On first time startup, the service will create a DocumentDB database and collection for you
                        // if none exist with these names.
                        DataBaseId = "runningpicsdb",
                        CollectionId = "runningpics_collection",
                        EndpointUrl = "https://runningpics.documents.azure.com:443/",
                        AuthorizationKey = "YCsHY3OCmggS5cd0ml7FrjSug1FTXdl7aBgo1gAicXT2e2zXVFSazLQdoTJ9MATLsxYRQVmvm6oF4n9sp5Izag=="
                    };
                }

                return _documentDbStorage;
            }
        }

        /// <summary>
        /// The Notification Hub's default full shared access signature.
        /// </summary>
        public override string HubFullSharedAccessSignature
        {
            get
            {
                return "Endpoint=sb://runningpicsnotification-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=ZFBL/YzCkBWltYhldmP4xoHyCukj2wODFarzABRWuEI=";
            }
        }

        /// <summary>
        /// The Notification Hub's name.
        /// </summary>
        public override string HubName
        {
            get { return "runningpicsnotificationhub"; }
        }

        /// <summary>
        /// The Application Insights instrumentation key. This value is read from the Web.config file.
        /// </summary>
        public override string InstrumentationKey
        {
            get { return "a463a98a-fdaa-4117-8011-f94b909aa97d"; }
        }

        /// <summary>
        /// The Azure Storage access key that is used for storing
        /// uploaded photos.
        /// </summary>
        public override string StorageAccessKey
        {
            get { return "b2Y5eNpiADN3UjxI47qyTPTUhhvq31suYNN0crpsUv6GyPA1/jgi8s8xlu7t+yo3/UAMZ2P+OTjcCRTT5d2XZA=="; }
        }

        /// <summary>
        /// The Azure Storage account name that is used for storing
        /// uploaded photos.
        /// </summary>
        public override string StorageAccountName
        {
            get { return "runningpicsapp"; }
        }
    }
}