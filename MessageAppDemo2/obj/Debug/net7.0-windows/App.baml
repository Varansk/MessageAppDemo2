   M S B A M L   `   `   `  ����J  FMessageAppDemo2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MessageAppDemo2MessageAppDemo2  5          MessageAppDemo2.App   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      /localclr-namespace:MessageAppDemo2     5        �� 	Resources  5       �� MergedDictionaries   Key �� 
TargetType �Name-  'System.Windows.Input.KeyboardNavigation   TabNavigation J� SnapsToDevicePixels � ColumnDefinitions ��Name � RowDefinitions	 ��Name
 ��Name K� ZIndex K� IsItemsHost   TabIndex ��Name �� CornerRadius   DirectionalNavigation ��Name �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value �� RelativeSource �� Mode �� AncestorType �� AncestorLevel �� Path�� 5	   
    5
      �� 5      �� 5      TabControlTemplate  " ��6A   .R�5      � $ templateRoot��5      $
}�true��5      $ Local=�5      $
 true��5       5      �� 5   "   $ ColumnDefinition0��63   �� 5   "   $ ColumnDefinition1��63   $��0 �6N    5      �� 5   "   $	 RowDefinition0��60   $
��Auto �6H   �� 5   "   $	 RowDefinition1��60   $��* �6H   .+�5      �� $
 headerPanel��5   !   $��0��5   !   $��0��5   !   $��2,2,2,0q�5   !   $ 1��5    !   
������ $
 true��5"   !   $ 1��5#   !   �� 5$      $ contentPanel��5%   !   $��1��5&   !   $��0��5'   !   $��10,0,0,0q�5(   !   #��z��5)   !   #��z��5*   !   #��z��5+   !   $ 7��5,   !   $ 	Contained=�5-   !   $ 2��5.   !   $ Local=�5/   !   ._�50   "   �� $ PART_SelectedContentHost��51   %   #��z��52   %   $��SelectedContent��53   %   # z 54   %   55      56       57      P� 58       �@��TabStripPlacement$ Bottom=�6C   . �59   "   �� $ headerPanel��6)    � ��$ 1��6V   �� 5:   "   $ contentPanel��6)    � ��$ 0��6W   �� 5;   "   $ RowDefinition0��6)    � ��$ * �6W   �� 5<   "   $ RowDefinition1��6)    � ��$
 Auto �6W   �� 5=   "   $ headerPanel��6)    � ��$ 2,0,2,2q�6T   5>      P� 5?       �@��TabStripPlacement$
 Left=�6C   . �5@   "   �� $ headerPanel��6)    � ��$ 0��6V   �� 5A   "   $ contentPanel��6)    � ��$ 0��6W   �� 5B   "   $ headerPanel��6)    � ��$ 0��6Y   �� 5C   "   $ contentPanel��6)    � ��$ 1��6Z   �� 5D   "   $ ColumnDefinition0��6)    � ��$
 Auto �6Y   �� 5E   "   $ ColumnDefinition1��6)    � ��$ * �6Y   �� 5F   "   $ RowDefinition0��6)    � ��$ * �6W   �� 5G   "   $ RowDefinition1��6)    � ��$ 0 �6W   �� 5H   "   $ headerPanel��6)    � ��$ 2,2,0,2q�6T   5I      P� 5J       �@��TabStripPlacement$ Right=�6C   . �5K   "   �� $ headerPanel��6)    � ��$ 0��6V   �� 5L   "   $ contentPanel��6)    � ��$ 0��6W   �� 5M   "   $ headerPanel��6)    � ��$ 1��6Y   �� 5N   "   $ contentPanel��6)    � ��$ 0��6Z   �� 5O   "   $ ColumnDefinition0��6)    � ��$ * �6Y   �� 5P   "   $ ColumnDefinition1��6)    � ��$
 Auto �6Y   �� 5Q   "   $ RowDefinition0��6)    � ��$ * �6W   �� 5R   "   $ RowDefinition1��6)    � ��$ 0 �6W   �� 5S   "   $ headerPanel��6)    � ��$ 0,2,2,2q�6T   5T      P� 5U       � {�$ false��6;   . �5V   "   �� $ templateRoot��6)   # � ��6e    � ��5W      5Y      �� 5[      TabItemTemplate  " ��6>   .R�5\      �� $ 
BorderRoot��5]      #��z��5^      $
��auto��5_      
������ 
������ #��z��5b      $	 0.5��5c      ._�5d      �  5e   "   �� 5f   &   $
��auto �64   �� 5g   &   $��2 �64   �� 5h   &   $
��auto �64   �� 5i   &   $��5 �64   .+�5k   "   �� $ content��5l   %   $��0��5m   %   $��Center=�5n   %   $��Center=�5o   %   #��z��5p   %   ���#AAAEAE5q   %   �� 5r   "   $
 Line��5s   %   $��2��5t   %   $
��auto��5u   %   $��2��5v   %   $	��Top=�5w   %   
������ $ 1��5y   %   5z      5{       5|      P� 5}       �@��
IsSelected$
 True��6<   . �5~   "   �� $ content��6)    6^   ��  �� $ FindAncestor=� TabItem$ 1��$ 
Background� � ���� 5   "   $
 Line��6)    6Q   ��  �� $ FindAncestor=� TabItem$ 1��$ 
Background� � ���� 5�   "   $ 
BorderRoot��6)    6X   ��  �� $ FindAncestor=�$ 1�� TabItem$ BorderBrush� � ��5�      5�      5�      %    5�      5�      