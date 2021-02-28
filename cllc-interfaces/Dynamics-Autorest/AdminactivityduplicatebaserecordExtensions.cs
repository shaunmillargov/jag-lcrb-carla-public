// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Gov.Lclb.Cllb.Interfaces
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for Adminactivityduplicatebaserecord.
    /// </summary>
    public static partial class AdminactivityduplicatebaserecordExtensions
    {
            /// <summary>
            /// Get adoxio_adminactivity_DuplicateBaseRecord from adoxio_adminactivities
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioAdminactivityid'>
            /// key: adoxio_adminactivityid of adoxio_adminactivity
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='filter'>
            /// </param>
            /// <param name='count'>
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            public static MicrosoftDynamicsCRMduplicaterecordCollection Get(this IAdminactivityduplicatebaserecord operations, string adoxioAdminactivityid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.GetAsync(adoxioAdminactivityid, top, skip, search, filter, count, orderby, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_adminactivity_DuplicateBaseRecord from adoxio_adminactivities
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioAdminactivityid'>
            /// key: adoxio_adminactivityid of adoxio_adminactivity
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='filter'>
            /// </param>
            /// <param name='count'>
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MicrosoftDynamicsCRMduplicaterecordCollection> GetAsync(this IAdminactivityduplicatebaserecord operations, string adoxioAdminactivityid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(adoxioAdminactivityid, top, skip, search, filter, count, orderby, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get adoxio_adminactivity_DuplicateBaseRecord from adoxio_adminactivities
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioAdminactivityid'>
            /// key: adoxio_adminactivityid of adoxio_adminactivity
            /// </param>
            /// <param name='top'>
            /// </param>
            /// <param name='skip'>
            /// </param>
            /// <param name='search'>
            /// </param>
            /// <param name='filter'>
            /// </param>
            /// <param name='count'>
            /// </param>
            /// <param name='orderby'>
            /// Order items by property values
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<MicrosoftDynamicsCRMduplicaterecordCollection> GetWithHttpMessages(this IAdminactivityduplicatebaserecord operations, string adoxioAdminactivityid, int? top = default(int?), int? skip = default(int?), string search = default(string), string filter = default(string), bool? count = default(bool?), IList<string> orderby = default(IList<string>), IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.GetWithHttpMessagesAsync(adoxioAdminactivityid, top, skip, search, filter, count, orderby, select, expand, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_adminactivity_DuplicateBaseRecord from adoxio_adminactivities
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioAdminactivityid'>
            /// key: adoxio_adminactivityid of adoxio_adminactivity
            /// </param>
            /// <param name='duplicateid'>
            /// key: duplicateid of duplicaterecord
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            public static MicrosoftDynamicsCRMduplicaterecord DuplicateBaseRecordByKey(this IAdminactivityduplicatebaserecord operations, string adoxioAdminactivityid, string duplicateid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>))
            {
                return operations.DuplicateBaseRecordByKeyAsync(adoxioAdminactivityid, duplicateid, select, expand).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get adoxio_adminactivity_DuplicateBaseRecord from adoxio_adminactivities
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioAdminactivityid'>
            /// key: adoxio_adminactivityid of adoxio_adminactivity
            /// </param>
            /// <param name='duplicateid'>
            /// key: duplicateid of duplicaterecord
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<MicrosoftDynamicsCRMduplicaterecord> DuplicateBaseRecordByKeyAsync(this IAdminactivityduplicatebaserecord operations, string adoxioAdminactivityid, string duplicateid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DuplicateBaseRecordByKeyWithHttpMessagesAsync(adoxioAdminactivityid, duplicateid, select, expand, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get adoxio_adminactivity_DuplicateBaseRecord from adoxio_adminactivities
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='adoxioAdminactivityid'>
            /// key: adoxio_adminactivityid of adoxio_adminactivity
            /// </param>
            /// <param name='duplicateid'>
            /// key: duplicateid of duplicaterecord
            /// </param>
            /// <param name='select'>
            /// Select properties to be returned
            /// </param>
            /// <param name='expand'>
            /// Expand related entities
            /// </param>
            /// <param name='customHeaders'>
            /// Headers that will be added to request.
            /// </param>
            public static HttpOperationResponse<MicrosoftDynamicsCRMduplicaterecord> DuplicateBaseRecordByKeyWithHttpMessages(this IAdminactivityduplicatebaserecord operations, string adoxioAdminactivityid, string duplicateid, IList<string> select = default(IList<string>), IList<string> expand = default(IList<string>), Dictionary<string, List<string>> customHeaders = null)
            {
                return operations.DuplicateBaseRecordByKeyWithHttpMessagesAsync(adoxioAdminactivityid, duplicateid, select, expand, customHeaders, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
            }

    }
}
